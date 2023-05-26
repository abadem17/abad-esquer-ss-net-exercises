using Common.Domain;

namespace Common.Persistence
{
	public interface IRepository : IRepositoryBase
	{
		T Add<T>(T entity) where T : Entity;
		T Remove<T>(T entity) where T : Entity;
		T Update<T>(T entity) where T : Entity;
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
