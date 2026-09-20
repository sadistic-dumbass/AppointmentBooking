using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces.Repositories;
public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(Guid patientId);
}