using System.ComponentModel.DataAnnotations;
namespace AppointmentSystem.Application.DTOs.Auth;
public class SignInRequestDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}