namespace hermes_api.Hermes.Infrastructure;

using Microsoft.EntityFrameworkCore;

public static class PostgresExtensions
{
    public static IServiceCollection InjectPostgresDatabase(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Database connection string is missing.");

        services.AddDbContext<HermesDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}