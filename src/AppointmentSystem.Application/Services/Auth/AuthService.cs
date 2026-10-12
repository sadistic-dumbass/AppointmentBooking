using AppointmentSystem.Application.DTOs.Auth;
using AppointmentSystem.Application.Interfaces.Auth;

namespace AppointmentSystem.Application.Services.Auth; 
public class AuthService : IAuthService
{
    public AuthService()
    {
        
    }

    public bool? SignIn(SignInRequestDto signInRequestDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}