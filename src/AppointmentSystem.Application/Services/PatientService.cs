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
        var existingPatient = await _patientRepository.GetByEmailAsync(request.Email.ToLower());

        if (existingPatient is not null) 
            throw new InvalidOperationException($"Patient with {request.Email} already exists.");
        
        var patient = new Patient(request.Email, request.Name, request.Password);
        await _patientRepository.AddAsync(patient);
        await _patientRepository.SaveChangesAsync();

        return MapToResponse(patient);
    }

    public async Task<IEnumerable<PatientResponse>> GetAllAsync()
    {
        var patients = await _patientRepository.GetAllAsync();

        return patients.Select(MapToResponse);
    }

    public async Task<PatientResponse?> GetByIdAsync(Guid id)
    {
        var doctor = await _patientRepository.GetByIdAsync(id);

        return doctor is null ? null : MapToResponse(doctor);
    }

    public async Task<PatientResponse> UpdateAsync(Guid id,UpdatePatientRequest request)
    {
        var patient = await _patientRepository.GetByIdAsync(id);

        if (patient is null)
            throw new KeyNotFoundException($"Patient with id '{id}' was not found.");

        var patientWithEmail = await _patientRepository.GetByEmailAsync(request.Email);

        if (patientWithEmail is not null && patientWithEmail.Id != id)
            throw new InvalidOperationException("A patient with this email already exists.");

        patient.UpdateDetails(request.Name,request.Email);

        _patientRepository.Update(patient);
        await _patientRepository.SaveChangesAsync();

        return MapToResponse(patient);
    }

    public async Task DeleteAsync(Guid id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);

        if (patient is null)
            throw new KeyNotFoundException($"Patient with id '{id}' was not found.");
 
        _patientRepository.Delete(patient);
        await _patientRepository.SaveChangesAsync();
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