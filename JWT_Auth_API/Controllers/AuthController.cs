using JWT_Auth_Service.DTOs;
using JWT_Auth_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Auth_API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : CustomBaseController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    //api/auth/
    [HttpPost]
    public async Task<IActionResult> CreateToken(LoginDto loginDto)
    {
        var result = await _authenticationService.CreateTokenAsync(loginDto);

        return ActionResultInstance(result);
    }

    [HttpPost]
    public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
    {
        var result = await _authenticationService.RevokeRefreshToken(refreshTokenDto.Token);

        return ActionResultInstance(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
    {
        var result = await _authenticationService.CreateTokenByRefreshToken(refreshTokenDto.Token);

        return ActionResultInstance(result);
    }
}