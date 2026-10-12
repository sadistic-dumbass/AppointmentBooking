using AppointmentSystem.Application.DTOs.Patient;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePatientRequest request, CancellationToken cancellationToken)
    {
        var patient = await _patientService.CreateAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var patients = await _patientService.GetAllAsync();

        return Ok(patients);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var patient = await _patientService.GetByIdAsync(id);

        if (patient is null)
            return NotFound();

        return Ok(patient);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdatePatientRequest updatePatientRequest, CancellationToken cancellationToken)
    {
        var patient = await _patientService.UpdateAsync(id, updatePatientRequest);

        if (patient is null)
            return NotFound();

        return Ok(patient);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _patientService.DeleteAsync(id);

        return NoContent();
    }
}