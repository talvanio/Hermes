using hermes_api.Hermes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace hermes_api.Hermes.Infrastructure;

public class HermesDbContext(DbContextOptions<HermesDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(u => u.Id);
            entity.HasIndex(u => u.Username).IsUnique();
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.UserType).HasMaxLength(20);
        });
    }
}