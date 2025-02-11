using Application.SaleTransactions.Dtos;
using Common.CQRS;
using Common.Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SaleTransactions.Queries
{
    public class GetPagedSalesQueryHandler : IQueryHandler<GetPagedSalesQuery, Page<SaleInfoModel>>
    {
        private readonly AppDbContext _context;

        public GetPagedSalesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Page<SaleInfoModel>> Handle(GetPagedSalesQuery request, CancellationToken cancellationToken)
        {
            var totalItems = await _context.Set<SaleTransaction>().CountAsync(cancellationToken);

            var sales = await _context.Set<SaleTransaction>()
                .OrderByDescending(s => s.Date)
                .Skip((int)((request.CurrentPage - 1) * request.ItemsPerPage))
                .Take(request.ItemsPerPage)
                .Select(s => new SaleInfoModel
                {
                    Date = s.Date,
                    Subtotal = s.TransactionItems.Sum(t => t.Quantity * t.UnitPrice),
                    Tax = s.TransactionItems.Sum(t => t.Tax),
                    Total = s.TransactionItems.Sum(t => (t.Quantity * t.UnitPrice) + t.Tax - t.Discount),
                    PaymentMethodType = s.PaymentMethodType
                })
                .ToListAsync(cancellationToken);

            return new Page<SaleInfoModel>(sales, request.CurrentPage, request.ItemsPerPage, totalItems);
        }
    }
}

