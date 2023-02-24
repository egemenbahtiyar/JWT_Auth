using AutoMapper;
using AutoMapper.Internal.Mappers;
using JWT_Auth_Data.Entities;
using JWT_Auth_Data.Interfaces;
using JWT_Auth_Service.DTOs;
using JWT_Auth_Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JWT_Auth_Service.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(UserManager<User> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _mapper = mapper;
        _roleManager = roleManager;
        _unitOfWork = unitOfWork;
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

    public async Task<Response<UserAppDto>> CreateAdminAsync(CreateAdminDto createAdminDto)
    {
        var adminRole = await _roleManager.Roles.Where(x=>x.Name == "Admin").FirstOrDefaultAsync();
        if (adminRole == null)
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
        }
        var user = new User { UserName = createAdminDto.UserName, City = "niğde", Email = "Egementyu@gmail.com" };
        var result = await _userManager.CreateAsync(user, createAdminDto.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "Admin");
            return Response<UserAppDto>.Success(_mapper.Map<UserAppDto>(user), 200);
        }
        return Response<UserAppDto>.Fail("Admin could not created", 400, true);
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