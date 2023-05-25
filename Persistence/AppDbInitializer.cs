using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence
{
	public class AppDbInitializer
	{
		private readonly AppDbContext _context;
		private readonly ILogger<AppDbInitializer> _logger;

		public AppDbInitializer(AppDbContext context, ILogger<AppDbInitializer> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task Run()
		{
			if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
			{
				await _context.Database.MigrateAsync();
			}

			_logger.LogInformation("Seeding database started.");

			// seed database by using the _context

			_logger.LogInformation("Seeding database done.");
		}
	}
}
