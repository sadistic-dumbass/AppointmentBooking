namespace AppointmentSystem.Domain.Entities;
public class DoctorAvailability : BaseEntity
{
    public Guid DoctorId { get; private set; }

    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }

    public DoctorAvailability(Guid doctorId, DateTime startDateTime, DateTime endDateTime)
    {
        DoctorId = doctorId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;

        ValidateAvailability();
    }

    private void ValidateAvailability()
    {
        if (EndDateTime <= StartDateTime)
            throw new Exception("End time must be after start time.");
        if (StartDateTime < DateTime.UtcNow)
            throw new Exception("Availability cannot be in the past.");
    }
}