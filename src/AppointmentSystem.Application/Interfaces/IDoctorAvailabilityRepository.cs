using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces;

public interface IDoctorAvailabilityRepository
{
    Task<DoctorAvailability?> GetAvailabilityAsync(Guid doctorId, DateTime startTime, DateTime endTime);
}