using IdentityService.Entities;
using IdentityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService userService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Login(string username, string password)
    {
       var res = await userService.Login(username, password);
        return Ok(res);
    }
}