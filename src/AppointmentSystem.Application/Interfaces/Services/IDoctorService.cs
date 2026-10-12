using AppointmentSystem.Application.DTOs.Doctor;

public interface IDoctorService
{
    Task<DoctorResponse> CreateAsync(CreateDoctorRequest request);
    Task<IEnumerable<DoctorResponse>> GetAllAsync();
    Task<DoctorResponse?> GetByIdAsync(Guid id);
    Task<DoctorResponse> UpdateAsync(Guid id, UpdateDoctorRequest request);
    Task DeleteAsync(Guid id);
}
