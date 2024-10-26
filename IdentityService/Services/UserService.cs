using IdentityService.Entities;
using IdentityService.Repositories;

namespace IdentityService.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<bool> Login(string username, string password)
    {
        return await userRepository.LoginUserAsync(username, password);
    }
}