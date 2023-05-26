using Application.SaleTransactions.Dtos;
using Common.CQRS;

namespace Application.SaleTransactions.Queries
{
	public class GetMonthSalesQueryHandler : IQueryHandler<GetMonthSalesQuery, List<SaleInfoModel>>
	{
		public Task<List<SaleInfoModel>> Handle(GetMonthSalesQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}