
namespace Application.SaleTransactions.Dtos
{
	public class SalesForMonthModel
	{
		public int Year { get; set; }
		public int Month { get; set; }
		public long TransactionsCount { get; set; }
		public decimal Subtotal { get; set; }
		public decimal Tax { get; set; }
		public decimal Total { get; set; }
	}
}
