using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoDbGenericRepository;

namespace IdentityService.Entities;

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; init; }
    
    public static UsersDbContext Create(IMongoDatabase database) => new(new DbContextOptionsBuilder<UsersDbContext>().UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName).Options);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>().ToCollection("users");
    }
}