using System.ComponentModel.DataAnnotations;
using hermes_api.Hermes.Domain.Entities;
using hermes_api.Hermes.Domain.Repositories;

namespace hermes_api.Hermes.Application.Identity;

public class IdentityHandler(IUserRepository userRepository)
{
    public async Task<bool> HandleLoginAsync(LoginPlainCredentialsDto loginCredentials)
    {
        var user = await userRepository.GetByUsernameAsync(loginCredentials.Username);
        
        return user != null && // TODO: user doesn't exists exception
               BCrypt.Net.BCrypt.Verify(loginCredentials.Password, user.PasswordHash);
    }

    public async Task HandleRegisterAsync(RegisterPlainCredentialsDto plainCredentials)
    {
        if (await userRepository.GetByUsernameAsync(plainCredentials.Username) != null)
        {
            throw new InvalidOperationException("Username already exists.");
        }
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainCredentials.Password);
        var newUser = new User(
            username: plainCredentials.Username, 
            passwordHash: hashedPassword, 
            email : plainCredentials.Email, 
            userType : plainCredentials.UserType);
        await userRepository.AddAsync(newUser);
    }

}