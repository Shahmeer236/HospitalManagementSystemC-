using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Dtos;
using HospitalManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PrescriptionDto>>> GetAllPrescriptions()
    {
        var prescriptions = await _prescriptionService.GetAllPrescriptionsAsync();
        return Ok(prescriptions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PrescriptionDto>> GetPrescriptionById(Guid id)
    {
        var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
        if (prescription == null)
        {
            return NotFound();
        }
        return Ok(prescription);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreatePrescription([FromBody] PrescriptionForCreation prescriptionForCreation)
    {
        var id = await _prescriptionService.CreatePrescriptionAsync(prescriptionForCreation);
        return CreatedAtAction(nameof(GetPrescriptionById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePrescription(Guid id, [FromBody] PrescriptionForUpdation prescriptionForUpdation)
    {
        if (id != prescriptionForUpdation.Id)
        {
            return BadRequest();
        }

        var result = await _prescriptionService.UpdatePrescriptionAsync(prescriptionForUpdation);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePrescription(Guid id)
    {
        var result = await _prescriptionService.DeletePrescriptionAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
