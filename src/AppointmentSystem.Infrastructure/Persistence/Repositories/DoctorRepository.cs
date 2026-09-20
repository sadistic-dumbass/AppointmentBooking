using AppointmentSystem.Application.Interfaces.Repositories;
using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class DoctorRepository : IDoctorRepository
{
    private readonly AppDbContext _dbContext;

    public DoctorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Doctor doctor)
    {
        await _dbContext.Doctors.AddAsync(doctor);
    }

    public void Delete(Doctor doctor)
    {
        _dbContext.Doctors.Remove(doctor);
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await _dbContext.Doctors.AsNoTracking().ToListAsync();
    }

    public async Task<Doctor?> GetByEmailAsync(string email)
    {
        return await _dbContext.Doctors.AsNoTracking().FirstOrDefaultAsync(d => d.Email == email);
    }

    public async Task<Doctor?> GetByIdAsync(Guid doctorId)
    {
        return await _dbContext.Doctors.AsNoTracking().FirstOrDefaultAsync(d => d.Id == doctorId);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Update(Doctor doctor)
    {
        _dbContext.Doctors.Update(doctor);
    }
}