namespace AppointmentSystem.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime CreatedOn { get; } = DateTime.UtcNow;
    public DateTime UpdatedOn { get; private set; } = DateTime.UtcNow;
    protected void MarkAsUpdated()
    {
        UpdatedOn = DateTime.UtcNow;
    }
}
