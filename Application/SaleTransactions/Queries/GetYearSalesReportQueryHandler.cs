using Application.SaleTransactions.Dtos;
using Common.CQRS;
using Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SaleTransactions.Queries
{
	public class GetYearSalesReportQueryHandler : IQueryHandler<GetYearSalesReportQuery, List<SalesForMonthModel>>
	{
		private readonly AppDbContext _context;
		public GetYearSalesReportQueryHandler(AppDbContext context)
        {
            _context = context;
        }

		public async Task<List<SalesForMonthModel>> Handle(GetYearSalesReportQuery request, CancellationToken cancellationToken)
        {
            // Obtener ventas agrupadas por mes
            var salesData = await _context.Set<SaleTransaction>()
                .Where(s => s.Date.Year == request.Year)
                .GroupBy(s => s.Date.Month)
                .Select(g => new SalesForMonthModel
                {
                    Year = request.Year,
                    Month = g.Key,
                    TransactionsCount = g.Count(),
                    Subtotal = g.Sum(s => s.TransactionItems.Sum(t => t.Quantity * t.UnitPrice)),
                    Tax = g.Sum(s => s.TransactionItems.Sum(t => t.Tax)),
                    Total = g.Sum(s => s.TransactionItems.Sum(t => (t.Quantity * t.UnitPrice) + t.Tax - t.Discount))
                })
                .ToListAsync(cancellationToken);

            //generar 12 meses con valores por defecto si no exite en la bd

            var fullReport = Enumerable.Range(1, 12)
                .Select(m => salesData.FirstOrDefault(s => s.Month == m) ?? new SalesForMonthModel
                {
                    Year = request.Year,
                    Month = m,
                    TransactionsCount = 0,
                    Subtotal = 0,
                    Tax = 0,
                    Total = 0
                })
                .ToList();

            return fullReport;
        }
	}
}
