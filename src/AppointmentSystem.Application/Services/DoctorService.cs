using AppointmentSystem.Application.DTOs.Doctors;
using AppointmentSystem.Application.Interfaces.Repositories;
using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<DoctorResponse> CreateAsync(CreateDoctorRequest request)
    {
        var existingDoctor = await _doctorRepository.GetByEmailAsync(request.Email);

        if (existingDoctor is not null)        
            throw new InvalidOperationException("A doctor with this email already exists.");

        var doctor = new Doctor(request.Name,request.Email,request.Password,request.Speciality);

        await _doctorRepository.AddAsync(doctor);
        await _doctorRepository.SaveChangesAsync();

        return MapToResponse(doctor);
    }

    public async Task<IEnumerable<DoctorResponse>> GetAllAsync()
    {
        var doctors = await _doctorRepository.GetAllAsync();

        return doctors.Select(MapToResponse);
    }

    public async Task<DoctorResponse?> GetByIdAsync(Guid id)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);

        return doctor is null ? null : MapToResponse(doctor);
    }

    public async Task<DoctorResponse> UpdateAsync(Guid id,UpdateDoctorRequest request)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);

        if (doctor is null)
            throw new KeyNotFoundException($"Doctor with id '{id}' was not found.");

        var doctorWithEmail =
            await _doctorRepository.GetByEmailAsync(request.Email);

        if (doctorWithEmail is not null && doctorWithEmail.Id != id)
            throw new InvalidOperationException("A doctor with this email already exists.");

        doctor.UpdateDetails(request.Name,request.Email,request.Speciality);

        _doctorRepository.Update(doctor);
        await _doctorRepository.SaveChangesAsync();

        return MapToResponse(doctor);
    }

    public async Task DeleteAsync(Guid id)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);

        if (doctor is null)
            throw new KeyNotFoundException($"Doctor with id '{id}' was not found.");
 
        _doctorRepository.Delete(doctor);
        await _doctorRepository.SaveChangesAsync();
    }

    private static DoctorResponse MapToResponse(Doctor doctor)
    {
        return new DoctorResponse
        {
            Id = doctor.Id,
            Name = doctor.Name,
            Email = doctor.Email,
            Speciality = doctor.Speciality,
            CreatedOn = doctor.CreatedOn,
            UpdatedOn = doctor.UpdatedOn
        };
    }
}