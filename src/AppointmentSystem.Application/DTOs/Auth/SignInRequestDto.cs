using System.ComponentModel.DataAnnotations;
namespace AppointmentSystem.Application.DTOs.Auth;
public class SignInRequestDto
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}