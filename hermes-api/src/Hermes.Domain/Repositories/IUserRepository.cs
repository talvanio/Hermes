
using hermes_api.Hermes.Domain.Entities;

namespace hermes_api.Hermes.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task AddAsync(User user);
}