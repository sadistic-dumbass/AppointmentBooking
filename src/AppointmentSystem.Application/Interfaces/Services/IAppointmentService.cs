public interface IAppointmentService
{
    Task<Guid?> BookAppointmentAsync(Guid doctorId, Guid patientId, DateTime startTime, DateTime endTime);
}