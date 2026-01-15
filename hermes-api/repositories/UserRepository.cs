using MongoDB.Driver;

public class UserRepository
{
    private readonly IMongoCollection<User> _collection;
    public UserRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<User>("users");
        }

    public async Task<User> GetUserByUsername(string username)
    {
        return await _collection.Find(u => u.Username == username).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _collection.InsertOneAsync(user);
    }


}