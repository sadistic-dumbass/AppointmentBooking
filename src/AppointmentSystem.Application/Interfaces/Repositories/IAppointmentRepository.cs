using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces.Repositories;
public interface IAppointmentRepository
{
    Task<bool> HasOverlappingAppointmentAsync(Guid doctorId, DateTime startTime, DateTime endTime);
    Task AddAsync(Appointment appointment);
}