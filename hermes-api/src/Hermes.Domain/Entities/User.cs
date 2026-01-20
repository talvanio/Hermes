public class User
{
    public string Id { get; set; } = null!;
    
    public string Username { get; set; } = null!;
    
    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}