namespace Common.Domain
{
	public abstract class Entity
	{
		public Guid Id { get; set; }
		public bool Deleted { get; set; }
	}
}
