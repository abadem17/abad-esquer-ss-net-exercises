using Common.Domain;
using Domain.Enums;

namespace Domain.Entities
{
	public class SaleTransaction : Entity
	{
		public DateTime Date { get; set; }
		public PaymentMethodType PaymentMethodType { get; set; }

		public virtual ICollection<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
	}
}
