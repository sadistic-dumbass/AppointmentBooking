using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Application.DTOs.Patient;

public class CreatePatientRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}