using Microsoft.AspNetCore.Identity;

namespace JWT_Auth_Data.Entities;

public class User: IdentityUser
{
    public string City { get; set; }
}