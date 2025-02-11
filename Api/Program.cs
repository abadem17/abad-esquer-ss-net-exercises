using Common.CQRS;
using MediatR;
using FluentValidation;
using Persistence;
using Application;
using Microsoft.EntityFrameworkCore;
using Common.Exceptions;
using Common.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Security;


var applicationAssembly = typeof(ApplicationEmptyClass).Assembly;
var persistenceAssembly = typeof(AppDbContext).Assembly;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Configurar JWT
var secretKey = Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JwtSettings:Issuer"],
            ValidAudience = configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(secretKey)
        };
    });
builder.Services.AddSingleton<JwtService>();
// Add MVC
builder.Services.AddControllers();

// Add Swagger https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR (CQRS)
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
builder.Services.AddValidatorsFromAssembly(applicationAssembly, ServiceLifetime.Singleton);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

// Add DbContext and migrations
builder.Services.AddDbContext<AppDbContext>(options =>
{
	var sqlConnectionString = configuration.GetConnectionString("PostgreSqlConnection");
	options.UseNpgsql(sqlConnectionString, x => x.MigrationsAssembly(persistenceAssembly.FullName));
});
builder.Services.AddTransient<IRepository, EfRepository<AppDbContext>>();
builder.Services.AddTransient<IReadOnlyRepository, ReadOnlyEfRepository<AppDbContext>>();
builder.Services.AddTransient<AppDbContextMigrator>();
builder.Services.AddTransient<AppDbInitializer>();

// Add application services by convention
applicationAssembly.ExportedTypes
	.Where(x => !x.IsAbstract && !x.IsInterface && x.Name.EndsWith("Service"))
	.ToList()
	.ForEach(service =>
	{
		var @interface = service.GetInterface("I" + service.Name);
		if (@interface != null)
		{
			builder.Services.AddTransient(@interface, service);
		}
	});

// Register services without convention
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Handle errors gloabally
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Run Migrations and DbInitializer
using (var scope = app.Services.CreateScope())
{
	var migrator = scope.ServiceProvider.GetRequiredService<AppDbContextMigrator>();
	var seeder = scope.ServiceProvider.GetRequiredService<AppDbInitializer>();

	await migrator.Run();
	await seeder.Run();
}

// Run the MVC app
app.Run();
