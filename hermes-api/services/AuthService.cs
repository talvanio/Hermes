public class AuthService
{
    private readonly UserRepository _userRepository;
    public AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> AuthenticateAsync(LoginRequest credentials)
    {
        User user = await _userRepository.GetUserByUsername(credentials.username);
        
        if (user == null) return false;
        return BCrypt.Net.BCrypt.Verify(credentials.password, user.PasswordHash);
    }

    public async Task RegisterAsync(string username, string password)
    {
            if (await _userRepository.GetUserByUsername(username) != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var newUser = new User 
            { 
                Username = username, 
                PasswordHash = hashedPassword 
            };
            await _userRepository.CreateAsync(newUser);
    }

}
