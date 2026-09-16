namespace AppointmentSystem.Domain.Entities;

using System.ComponentModel.DataAnnotations;

public class Doctor : BaseEntity
{
    [Required]
    public string Email { get; private set; }
    public string Name { get; private set; }
    public string PasswordHash { get; private set; }
    public string Speciality { get; private set; }
    public ICollection<Appointment> Appointments { get; private set; } = [];
    public ICollection<DoctorAvailability> Availabilities { get; private set; } = [];
    public Doctor(string email, string name, string passwordHash, string speciality)
    {
        Email = email;
        Name = name;
        PasswordHash = passwordHash;
        Speciality = speciality;
    }
}