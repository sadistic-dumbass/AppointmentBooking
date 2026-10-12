using AppointmentSystem.Application.DTOs.Auth;

namespace AppointmentSystem.Application.Interfaces.Auth;
public interface IAuthService
{
    public bool? SignIn(SignInRequestDto signInRequestDto, CancellationToken cancellationToken);   
}