public class User
{


    public User(string username, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(username))
        throw new ArgumentException("Username cannot be empty.");
        Username = username.ToLower();
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
    }

    public string Id { get; private set; } = null!;
    
    public string Username { get; private set; } = null!;
    
    public string PasswordHash { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; }
}