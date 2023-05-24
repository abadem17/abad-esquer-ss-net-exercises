using Common.Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
	public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
	{
		public SchoolRepository(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
