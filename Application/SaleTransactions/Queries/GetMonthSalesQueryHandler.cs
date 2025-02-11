using Application.SaleTransactions.Dtos;
using Common.CQRS;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SaleTransactions.Queries
{
    public class GetMonthSalesQueryHandler : IQueryHandler<GetMonthSalesQuery, List<SaleInfoModel>>
    {
        private readonly AppDbContext _context;

        public GetMonthSalesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SaleInfoModel>> Handle(GetMonthSalesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<SaleTransaction>()
                .Where(s => s.Date.Year == request.Year && s.Date.Month == request.Month)
                .Select(s => new SaleInfoModel
                {
                    Date = s.Date,
                    Subtotal = s.TransactionItems.Sum(t => t.Quantity * t.UnitPrice),
                    Tax = s.TransactionItems.Sum(t => t.Tax),
                    Total = s.TransactionItems.Sum(t => (t.Quantity * t.UnitPrice) + t.Tax - t.Discount),
                    PaymentMethodType = s.PaymentMethodType
                })
                .ToListAsync(cancellationToken);
        }
    }
}
