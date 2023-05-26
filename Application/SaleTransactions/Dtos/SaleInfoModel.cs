using Domain.Enums;

namespace Application.SaleTransactions.Dtos
{
	public class SaleInfoModel
	{
		public DateTime Date { get; set; }
		public decimal Subtotal { get; set; }
		public decimal Tax { get; set; }
		public decimal Total { get; set; }
		public PaymentMethodType PaymentMethodType { get; set; }
	}
}