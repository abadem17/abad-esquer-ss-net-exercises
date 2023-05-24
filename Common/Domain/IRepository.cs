namespace Common.Domain
{
	public interface IRepository<T> where T : Entity
	{
		T? FindById(Guid id);
		T Create(T entity);
		T Update(T entity);
		void SoftDelete(Guid id);
		int SaveChanges();
	}
}
