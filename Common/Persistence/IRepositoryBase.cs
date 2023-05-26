using Common.Domain;

namespace Common.Persistence
{
	public interface IRepositoryBase
	{
		IQueryable<T> Query<T>() where T : Entity;
		Task<T?> GetAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : Entity;
	}
	
}
