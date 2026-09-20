using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Application.DTOs.Doctors;

public class UpdateDoctorRequest
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Speciality { get; set; } = string.Empty;
}