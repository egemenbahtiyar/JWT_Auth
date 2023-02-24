using JWT_Auth_Data.Entities;
using JWT_Auth_Service.DTOs;

namespace JWT_Auth_Service.Interfaces;

public interface ITokenService
{
    TokenDto CreateToken(User user);
}