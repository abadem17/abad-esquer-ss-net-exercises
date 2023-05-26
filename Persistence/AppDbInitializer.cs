using Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence
{
	public class AppDbInitializer
	{
		private readonly AppDbContext _context;
		private readonly IRepository _repository;
		private readonly ILogger<AppDbInitializer> _logger;

		public AppDbInitializer(AppDbContext context, IRepository repository, ILogger<AppDbInitializer> logger)
		{
			_context = context;
			_repository = repository;
			_logger = logger;
		}

		public async Task Run()
		{
			if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
			{
				await _context.Database.MigrateAsync();
			}

			_logger.LogInformation("Seeding database started.");

			// seed database by using the _repository

			_logger.LogInformation("Seeding database done.");
		}
	}
}
