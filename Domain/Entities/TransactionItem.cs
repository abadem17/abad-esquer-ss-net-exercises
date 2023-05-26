using Common.Domain;

namespace Domain.Entities
{
	public class TransactionItem : Entity
	{
		public Guid SaleTransactionId { get; set; }
		public Guid ProductId { get; set; }
		public decimal Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Discount { get; set; }
		public decimal Tax { get; set; }

		public virtual SaleTransaction SaleTransaction { get; set; } = null!;
		public virtual Product Product { get; set; } = null!;
	}
}
