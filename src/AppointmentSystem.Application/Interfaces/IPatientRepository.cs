using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces;

public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(Guid patientId);
}