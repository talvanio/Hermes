public record UserPlainCredentialsDTO
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}