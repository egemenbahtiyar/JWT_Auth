namespace JWT_Auth_Service.DTOs;

public class CreateAdminDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string Password { get; set; }
}