public record UserPlainCredentialsDTO(string Username, string Password)
{
    public string Username { get; init; } = Username?.ToLower().Trim() 
        ?? throw new ArgumentException("Username is required", nameof(Username));

    public string Password { get; init; } = Password 
        ?? throw new ArgumentException("Password is required", nameof(Password));
}