using MongoDB.Driver;

public class MongoUserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _collection;
    public MongoUserRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<User>("users");
        }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _collection.Find(u => u.Username == username).FirstOrDefaultAsync();
    }

    public async Task AddAsync(User user)
    {
        await _collection.InsertOneAsync(user);
    }


}
