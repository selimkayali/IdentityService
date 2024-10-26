using IdentityService.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Repositories;

public class UserRepository(UsersDbContext dbContext) : IUserRepository
{
    public async Task<bool> LoginUserAsync(string username, string password)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(user =>
            (user.UserName == username || user.Email == username) && user.PasswordHash == password);

        return user is not null;
    }
}