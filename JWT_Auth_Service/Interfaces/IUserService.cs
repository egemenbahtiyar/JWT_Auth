using JWT_Auth_Data.Entities;
using JWT_Auth_Service.DTOs;

namespace JWT_Auth_Service.Interfaces;

public interface IUserService
{
    Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
    Task<Response<UserAppDto>> CreateAdminAsync(CreateAdminDto createAdminDto);

    Task<Response<UserAppDto>> GetUserByNameAsync(string userName);
    
    Task<Response<List<UserAppDto>>> GetAllUsersAsync();
}