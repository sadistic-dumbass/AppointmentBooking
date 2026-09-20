using AppointmentSystem.Application.Interfaces.Repositories;
using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
    public AppointmentService(IDoctorRepository doctorRepository, IPatientRepository patientRepository, IAppointmentRepository appointmentRepository, IDoctorAvailabilityRepository doctorAvailabilityRepository)
    {
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _appointmentRepository = appointmentRepository;
        _doctorAvailabilityRepository = doctorAvailabilityRepository;
    }

    public async Task<Guid?> BookAppointmentAsync(Guid doctorId, Guid patientId, DateTime startTime, DateTime endTime)
    {
        Doctor? doctor = await _doctorRepository.GetByIdAsync(doctorId);
        if (doctor == null) throw new Exception("Doctor not Found.");

        Patient? patient = await _patientRepository.GetByIdAsync(patientId);
        if (patient == null) throw new Exception("Patient not Found.");

        DoctorAvailability? doctorAvailability = await _doctorAvailabilityRepository.GetAvailabilityAsync(doctorId, startTime, endTime);
        if (doctorAvailability is null)
            throw new Exception("Doctor is not available for the requested time.");

        if (await _appointmentRepository.HasOverlappingAppointmentAsync(doctorId, startTime, endTime))
            throw new Exception("Appointment is Overlapping");

        Appointment appointment = new Appointment(doctorId, patientId, startTime, endTime);

        await _appointmentRepository.AddAsync(appointment);

        return appointment.Id;
    }
}