using AppointmentSystem.Domain.Entities;
namespace AppointmentSystem.Application.Interfaces;

public interface IDoctorRepository
{
    Task<Doctor?> GetByIdAsync(Guid doctorId);
}