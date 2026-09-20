using AppointmentSystem.Application.DTOs.Doctors;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorsController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDoctorRequest request)
    {
        var doctor = await _doctorService.CreateAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doctors = await _doctorService.GetAllAsync();

        return Ok(doctors);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var doctor = await _doctorService.GetByIdAsync(id);

        if (doctor is null)
            return NotFound();

        return Ok(doctor);
    }
}