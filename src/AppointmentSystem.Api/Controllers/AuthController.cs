using AppointmentSystem.Application.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    public AuthController()
    {
        
    }

    [HttpPost("/login")]
    public IActionResult SignIn(SignInRequestDto signInRequest, CancellationToken cancellationToken)
    {
        return Ok();
    }
}