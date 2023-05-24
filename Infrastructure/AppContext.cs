using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	public class AppContext : DbContext
	{
		public AppContext(DbContextOptions<AppContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
		}
	}
}