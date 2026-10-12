using AppointmentSystem.Application.Interfaces.Repositories;
using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class PatientRepository : IPatientRepository
{
    private readonly AppDbContext _dbContext;

    public PatientRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Patient patient)
    {
        await _dbContext.Patients.AddAsync(patient);
    }

    public void Delete(Patient patient)
    {
        _dbContext.Patients.Remove(patient);
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _dbContext.Patients.AsNoTracking().ToListAsync();
    }

    public async Task<Patient?> GetByEmailAsync(string email)
    {
        return await _dbContext.Patients.AsNoTracking().FirstOrDefaultAsync(d => d.Email == email);
    }

    public async Task<Patient?> GetByIdAsync(Guid patientId)
    {
        return await _dbContext.Patients.AsNoTracking().FirstOrDefaultAsync(d => d.Id == patientId);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Update(Patient patient)
    {
        _dbContext.Patients.Update(patient);
    }
}