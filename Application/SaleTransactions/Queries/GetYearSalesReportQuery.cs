using Application.SaleTransactions.Dtos;
using Common.CQRS;
using System.Collections.Generic;

namespace Application.SaleTransactions.Queries
{
	public class GetYearSalesReportQuery : IQuery<List<SalesForMonthModel>>
	{
		public int Year { get; set; }
		public GetYearSalesReportQuery(int year)
        {
            Year = year;
        }
		public GetYearSalesReportQuery(){}
	}
}
