namespace AppointmentSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class Patient : BaseEntity
{
    [Required]
    public string Email { get; private set; }
    public string Name { get; private set; }
    public string PasswordHash { get; private set; }
    public Patient(string email, string name, string passwordHash)
    {
        Email = email;
        Name = name;
        PasswordHash = passwordHash;
    }
}