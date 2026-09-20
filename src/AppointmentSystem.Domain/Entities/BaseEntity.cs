namespace AppointmentSystem.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; private set;} = Guid.NewGuid();
    public DateTime CreatedOn { get; private set;} = DateTime.UtcNow;
    public DateTime UpdatedOn { get; private set; } = DateTime.UtcNow;
    protected void MarkAsUpdated()
    {
        UpdatedOn = DateTime.UtcNow;
    }
}
