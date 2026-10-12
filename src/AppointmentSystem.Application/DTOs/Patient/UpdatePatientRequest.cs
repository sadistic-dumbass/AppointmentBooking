using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Application.DTOs.Patient;

public class UpdatePatientRequest
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}