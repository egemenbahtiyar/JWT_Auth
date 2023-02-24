using JWT_Auth_Service.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Auth_API.Controllers;

public class CustomBaseController : ControllerBase
{
    public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}