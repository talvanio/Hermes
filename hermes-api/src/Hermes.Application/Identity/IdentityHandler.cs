public class IdentityHandler
{
    private readonly IUserRepository _userRepository;
    public IdentityHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> HandleLoginAsync(UserPlainCredentialsDTO plainCredentials)
    {
        User? user = await _userRepository.GetByUsernameAsync(plainCredentials.Username);
        
        if (user == null) return false; // TODO: user doesn't exists exception
        return BCrypt.Net.BCrypt.Verify(plainCredentials.Password, user.PasswordHash);
    }

    public async Task HandleRegisterAsync(string username, string password)
    {
            if (await _userRepository.GetByUsernameAsync(username) != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var newUser = new User 
            { 
                Username = username, 
                PasswordHash = hashedPassword 
            };
            await _userRepository.AddAsync(newUser);
    }

}
