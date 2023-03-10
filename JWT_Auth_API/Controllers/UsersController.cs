using JWT_Auth_Service.DTOs;
using JWT_Auth_Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Auth_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController: CustomBaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
    }
    
    [HttpPost("CreateAdmin")]
    public async Task<IActionResult> CreateAdmin(CreateAdminDto createAdminDto)
    {
        return ActionResultInstance(await _userService.CreateAdminAsync(createAdminDto));
    }
    
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return ActionResultInstance(await _userService.GetAllUsersAsync());
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
    }
}