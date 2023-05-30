using Application.SaleTransactions.Dtos;
using Common.CQRS;

namespace Application.SaleTransactions.Queries
{
	public class GetYearSalesReportQuery : IQuery<List<SalesForMonthModel>>
	{
		public int Year { get; set; }
	}
}
