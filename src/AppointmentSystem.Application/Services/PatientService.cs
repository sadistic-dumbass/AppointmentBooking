using AppointmentSystem.Application.DTOs.Patient;
using AppointmentSystem.Application.Interfaces.Repositories;
using AppointmentSystem.Domain.Entities;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    public async Task<PatientResponse> CreateAsync(CreatePatientRequest request)
    {
        var existingPatient = _patientRepository.GetByEmailAsync(request.Email.ToLower());

        if (existingPatient is not null) 
            throw new InvalidOperationException($"Patient with {request.Email} already exists.");
        
        var patient = new Patient(request.Email, request.Name, request.Password);
        await _patientRepository.AddAsync(patient);
        await _patientRepository.SaveChangesAsync();

        return MapToResponse(patient);
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PatientResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PatientResponse?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PatientResponse> UpdateAsync(Guid id, UpdatePatientRequest request)
    {
        throw new NotImplementedException();
    }

    private static PatientResponse MapToResponse(Patient patient)
    {
        return new PatientResponse
        {
            Id = patient.Id,
            Name = patient.Name,
            Email = patient.Email,
            CreatedOn = patient.CreatedOn,
            UpdatedOn = patient.UpdatedOn
        };
    }
}