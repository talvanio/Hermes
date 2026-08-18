using hermes_api.Hermes.Domain.Entities;
using hermes_api.Hermes.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace hermes_api.Hermes.Infrastructure.Repositories;

public class PostgresUserRepository(HermesDbContext context) : IUserRepository
{
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task AddAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }
}