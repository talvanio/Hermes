using MongoDB.Driver;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddHermesDatabase(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Database connection string is missing.");

            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(settings);
            
            services.AddSingleton<IMongoDatabase>(client.GetDatabase("HermesDB"));

            return services;
        }

}