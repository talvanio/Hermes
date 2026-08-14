using hermes_api.Hermes.Domain.Entities;
using hermes_api.Hermes.Domain.Repositories;
using MongoDB.Driver;

namespace hermes_api.Hermes.Infrastructure.Repositories;

public class MongoUserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _collection;
    public MongoUserRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<User>("users");
        }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _collection.Find(u => u.Username == username).FirstOrDefaultAsync();
    }

    public async Task AddAsync(User user)
    {
        await _collection.InsertOneAsync(user);
    }


}
