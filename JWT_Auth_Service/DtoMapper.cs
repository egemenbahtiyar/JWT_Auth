using AutoMapper;
using JWT_Auth_Data.Entities;
using JWT_Auth_Service.DTOs;

namespace JWT_Auth_Service;

internal class DtoMapper: Profile
{
    public DtoMapper()
    {
        CreateMap<User,UserAppDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}