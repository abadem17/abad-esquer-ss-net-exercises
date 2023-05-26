using Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace Common.Persistence
{
	public class EfRepository : EfRepositoryBase, IRepository
	{
		public EfRepository(DbContext context)
			: base(context, false)
		{
		}

		public T Add<T>(T entity) where T : Entity
		{
			if (entity is null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			var result = Set<T>().Add(entity);
			return result.Entity;
		}

		public T Remove<T>(T entity) where T : Entity
		{
			if (entity is null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			var result = Set<T>().Remove(entity);
			return result.Entity;
		}

		public T Update<T>(T entity) where T : Entity
		{
			if (entity is null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			var result = Set<T>().Attach(entity);
			Context.Entry(entity).State = EntityState.Modified;
			return result.Entity;
		}

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return Context.SaveChangesAsync(cancellationToken);
		}
	}

	public class EfRepository<TContext> : EfRepository
		where TContext : DbContext
	{
		public EfRepository(TContext context)
			: base(context)
		{
		}
	}
}
