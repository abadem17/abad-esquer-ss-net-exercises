using Common.Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
	{
		public SchoolRepository(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
