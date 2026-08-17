using hermes_api.Hermes.Domain.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace hermes_api.Hermes.Infrastructure;

public static class MongoExtensions
{

    private static MongoClient FetchMongoClientFromConnectionString(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Database connection string is missing.");
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        return new MongoClient(settings);
    }

    public static IServiceCollection InjectMongoDatabase(this IServiceCollection services, IConfiguration config)
    {
        var mongoClient = FetchMongoClientFromConnectionString(config);
        services.AddSingleton<IMongoClient>(mongoClient);
        services.AddScoped(sp => mongoClient.GetDatabase("HermesDB"));            
        return services;
    }

    public static void AddBsonMappings()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(User)))
        {
            BsonClassMap.RegisterClassMap<User>(cm => 
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id) 
                    .SetIdGenerator(StringObjectIdGenerator.Instance) // Handle auto-generation for string Ids
                    .SetSerializer(new StringSerializer(MongoDB.Bson.BsonType.ObjectId)); // Ensure BSON compatibility
            });
            
        }
    }


}