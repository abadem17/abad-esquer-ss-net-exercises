using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<SaleTransaction> SaleTransaction { get; set; }
		public DbSet<TransactionItem> transactionItems { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}