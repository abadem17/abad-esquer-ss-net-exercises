using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence
{
	public abstract class EfRepositoryBase : IRepositoryBase
	{
		private readonly bool _isReadOnly;
		protected DbContext Context { get; }

		protected EfRepositoryBase(DbContext context, bool isReadOnly)
		{
			_isReadOnly = isReadOnly;
			Context = context ?? throw new ArgumentNullException(nameof(context));
		}
		protected virtual DbSet<T> Set<T>()
			where T : class
		{
			return Context.Set<T>();
		}

		public Task<T?> GetAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : Entity
		{
			return Set<T>().FindAsync(new object[] { id }, cancellationToken).AsTask();
		}

		public IQueryable<T> Query<T>() where T : Entity
		{
			var query = (IQueryable<T>)Set<T>();
			if (_isReadOnly)
			{
				query = query.AsNoTracking();
			}
			return query;
		}
	}
}
