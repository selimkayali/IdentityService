using IdentityService.Entities;

namespace IdentityService.Repositories;

public interface IUserRepository
{
    Task<bool> LoginUserAsync(string username, string password);
}