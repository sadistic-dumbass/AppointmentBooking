using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces.Repositories;
public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(Guid patientId);
    Task<Patient?> GetByEmailAsync(string email);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task AddAsync(Patient patient);
    void Update(Patient patient);
    void Delete(Patient patient);
    Task SaveChangesAsync();
}