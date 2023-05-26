using Common.Domain;

namespace Domain.Entities
{
	public class Product : Entity
	{
		public string Name { get; set; } = null!;
		public string Sku { get; set; } = null!;
		public decimal UnitPrice { get; set; }
		public long Stock { get; set; }
		public Guid CategoryId { get; set; }

		public virtual Category Category { get; set; } = null!;

		public virtual ICollection<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
	}
}
