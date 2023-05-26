using Common.Domain;

namespace Domain.Entities
{
	public class Category : Entity
	{
		public string Name { get; set; } = null!;

		public virtual ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
