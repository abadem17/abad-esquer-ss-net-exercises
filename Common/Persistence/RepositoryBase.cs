using Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace Common.Persistence
{
	public class RepositoryBase<T> : IRepository<T> where T : Entity
	{
		private readonly DbContext _dbContext;

		public RepositoryBase(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		// Marked as protected as IQueryable should not be exposed on other layers.
		// Is better to return a List<T> on specific repository methods.
		protected IQueryable<T> Query() { 
			return _dbContext.Set<T>();
		}

		// Need to call this methoid after an entity is modified to apply ther changes to the database.
		public int SaveChanges()
		{
			return _dbContext.SaveChanges();
		}

		public T? FindById(Guid id)
		{
			var entity = Query().Where(x => x.Id == id).FirstOrDefault();
			return entity;
		}

		public T Create(T entity)
		{
			_dbContext.Add(entity);
			return entity;
		}

		public T Update(T entity)
		{
			var dbSet = _dbContext.Set<T>();
			dbSet.Update(entity);
			return entity;
		}

		public void SoftDelete(Guid id)
		{
			var entity = Query().Where(x => x.Id == id).FirstOrDefault();
			if (entity != null)
			{
				entity.Deleted = true;
			}
		}
	}
}
