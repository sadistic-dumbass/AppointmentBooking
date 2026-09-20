using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces.Repositories;

public interface IDoctorRepository
{
    Task<Doctor?> GetByIdAsync(Guid doctorId);
    Task<Doctor?> GetByEmailAsync(string email);
    Task<IEnumerable<Doctor>> GetAllAsync();
    Task AddAsync(Doctor doctor);
    void Update(Doctor doctor);
    void Delete(Doctor doctor);
    Task SaveChangesAsync();
}