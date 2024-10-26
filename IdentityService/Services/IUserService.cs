using IdentityService.Entities;

namespace IdentityService.Services;

public interface IUserService
{
    Task<bool> Login(string username, string password);
}