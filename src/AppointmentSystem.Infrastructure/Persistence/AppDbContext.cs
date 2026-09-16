using Microsoft.EntityFrameworkCore;
using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Infrastructure.Persistence;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<DoctorAvailability> DoctorAvailabilities { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>()
            .HasMany(a => a.Appointments)
            .WithOne(a => a.Doctor)
            .HasForeignKey(d => d.DoctorId);

        modelBuilder.Entity<Patient>()
            .HasMany(a => a.Appointments)
            .WithOne(p => p.Patient)
            .HasForeignKey(p => p.PatientId);

        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.Availabilities)
            .WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId);
        
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.Property(d => d.Email).IsRequired();
            entity.Property(d => d.Name).IsRequired();
            entity.Property(d => d.PasswordHash).IsRequired();
            entity.Property(d => d.Speciality).IsRequired();
            entity.HasIndex(d => d.Email).IsUnique();
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(p => p.Email).IsRequired();
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.PasswordHash).IsRequired();
            entity.HasIndex(p => p.Email).IsUnique();
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.Property(a => a.Status).HasConversion<string>();
        });

        modelBuilder.Entity<DoctorAvailability>(entity =>
        {
            entity.Property(d => d.StartDateTime).IsRequired();
            entity.Property(d => d.EndDateTime).IsRequired();
        });
    }
}