using Common.Persistence;
using Microsoft.Extensions.Logging;

namespace Persistence
{
	public class AppDbContextMigrator : DbContextMigrator<AppDbContext>
    {
        public AppDbContextMigrator(AppDbContext context, ILogger<AppDbContextMigrator> logger)
              : base(context, logger)
        {
        }
    }
}
