namespace hermes_api.Hermes.Domain.Entities;

public class User
{


    public User(string username, string passwordHash, string email, string userType)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be empty.");
        Username = username.ToLower();
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
        Email = email;
        UserType = userType;
    }

    public int Id { get; private set; } = default!;

    public string Username { get; private set; } = default!;
    public string Email { get; set; } = default!;

    public string PasswordHash { get; private set; } = default!;

    public string UserType { get; set; } = default!;

    public DateTime CreatedAt { get; private set; }
}