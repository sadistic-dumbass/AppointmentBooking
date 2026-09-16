using AppointmentSystem.Domain.Enums;
namespace AppointmentSystem.Domain.Entities;

public class Appointment : BaseEntity
{
    public Guid DoctorId { get; private set; }
    public Guid PatientId { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public AppointmentStatus Status { get; private set; }

    public Appointment(Guid doctorId, Guid patientId, DateTime startTime, DateTime endTime)
    {
        DoctorId = doctorId;
        PatientId = patientId;
        StartTime = startTime;
        EndTime = endTime;

        ValidateAppointment();

        Status = AppointmentStatus.Pending;
    }

    private void ValidateAppointment()
    {
        if (StartTime < DateTime.UtcNow)
            throw new Exception("Appointment cannot be in the past.");

        if (EndTime <= StartTime)
            throw new Exception("End time must be after start time.");
    }

    public void Confirm()
    {
        if (Status != AppointmentStatus.Pending)
            throw new Exception("Only pending appointments can be confirmed.");

        Status = AppointmentStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status != AppointmentStatus.Pending && Status != AppointmentStatus.Confirmed)
            throw new Exception("Only pending or confirmed appointments can be cancelled.");

        Status = AppointmentStatus.Cancelled;
    }

    public void Complete()
    {
        if (Status != AppointmentStatus.Confirmed)
            throw new Exception("Only confirmed appointments can be completed.");

        Status = AppointmentStatus.Completed;
    }
}