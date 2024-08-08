using HospitalManagementSystem.Dtos.Appointment;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAppointments([FromQuery] string? search)
    {
        var appointments = await _appointmentService.GetAppointmentsAsync(search);
        return Ok(appointments);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromBody] AppointmentForCreation appointmentForCreation)
    {
        if (!TimeSpan.TryParse(appointmentForCreation.AppointmentTime, out TimeSpan appointmentTime))
        {
            return BadRequest("Invalid time format");
        }

        // Pass the AppointmentForCreation DTO directly to the service
        var appointmentId = await _appointmentService.CreateAppointmentAsync(appointmentForCreation);
        return CreatedAtAction(nameof(GetAppointmentById), new { id = appointmentId }, appointmentId);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointmentById(Guid id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] AppointmentForUpdation appointmentForUpdation)
    {
        if (id != appointmentForUpdation.Id)
        {
            return BadRequest();
        }

        var success = await _appointmentService.UpdateAppointmentAsync(appointmentForUpdation);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(Guid id)
    {
        var success = await _appointmentService.DeleteAppointmentAsync(id);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}
