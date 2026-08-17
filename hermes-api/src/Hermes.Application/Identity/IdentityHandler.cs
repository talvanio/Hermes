using hermes_api.Hermes.Domain.Entities;
using hermes_api.Hermes.Domain.Repositories;

namespace hermes_api.Hermes.Application.Identity;

public class IdentityHandler(IUserRepository userRepository)
{
    public async Task<bool> HandleLoginAsync(UserPlainCredentialsDTO plainCredentials)
    {
        var user = await userRepository.GetByUsernameAsync(plainCredentials.Username);
        
        return user != null && // TODO: user doesn't exists exception
               BCrypt.Net.BCrypt.Verify(plainCredentials.Password, user.PasswordHash);
    }

    public async Task HandleRegisterAsync(string username, string password)
    {
        if (await userRepository.GetByUsernameAsync(username) != null)
        {
            throw new InvalidOperationException("Username already exists.");
        }
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var newUser = new User(username: username, passwordHash: hashedPassword);
        await userRepository.AddAsync(newUser);
    }

}