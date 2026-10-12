using AppointmentSystem.Application.DTOs.Patient;

public interface IPatientService
{
    Task<PatientResponse> CreateAsync(CreatePatientRequest request);
    Task<IEnumerable<PatientResponse>> GetAllAsync();
    Task<PatientResponse?> GetByIdAsync(Guid id);
    Task<PatientResponse> UpdateAsync(Guid id, UpdatePatientRequest request);
    Task DeleteAsync(Guid id);
}