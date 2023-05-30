using Application.SaleTransactions.Dtos;
using Common.CQRS;

namespace Application.SaleTransactions.Queries
{
	internal class GetYearSalesReportQueryHandler : IQueryHandler<GetYearSalesReportQuery, List<SalesForMonthModel>>
	{
		public Task<List<SalesForMonthModel>> Handle(GetYearSalesReportQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
