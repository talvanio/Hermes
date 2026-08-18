namespace hermes_api.Hermes.Application.Identity;


public record RegisterPlainCredentialsDto(string Username, string Password, string Email,string UserType)
{
    public string Username { get; init; } = Username?.ToLower().Trim() 
                                            ?? throw new ArgumentException("Username is required", nameof(Username));

    public string Password { get; init; } = Password 
                                            ?? throw new ArgumentException("Password is required", nameof(Password));

    public string Email { get; init; } = Email
                                         ?? throw new ArgumentException("Email is required", nameof(Email));

    public string UserType { get; init; } = UserType
                                            ?? throw new ArgumentException("User Type is required", nameof(UserType));

}