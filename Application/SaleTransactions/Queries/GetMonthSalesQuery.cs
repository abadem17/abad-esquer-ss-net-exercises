using Application.SaleTransactions.Dtos;
using Common.CQRS;

namespace Application.SaleTransactions.Queries
{
	public class GetMonthSalesQuery : IQuery<List<SaleInfoModel>>
	{
		public int Month { get; set; } // 1 is January
		public int Year { get; set; }
	}
}