using AutoMapper;
using AutoMapper.Internal.Mappers;
using JWT_Auth_Data.Entities;
using JWT_Auth_Service.DTOs;
using JWT_Auth_Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JWT_Auth_Service.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = new User { Email = createUserDto.Email, UserName = createUserDto.UserName, City = createUserDto.City};

        var result = await _userManager.CreateAsync(user, createUserDto.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();

            return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
        }
        return Response<UserAppDto>.Success(_mapper.Map<UserAppDto>(user), 200);
    }

    public async Task<Response<UserAppDto>> GetUserByNameAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
        {
            return Response<UserAppDto>.Fail("UserName not found", 404, true);
        }

        return Response<UserAppDto>.Success(_mapper.Map<UserAppDto>(user), 200);
    }

    public async Task<Response<List<UserAppDto>>> GetAllUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        return Response<List<UserAppDto>>.Success(_mapper.Map<List<UserAppDto>>(users), 200);
    }
}