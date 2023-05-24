using Common.Domain;

namespace Domain.Entities
{
	public class School : Entity
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
	}
}
