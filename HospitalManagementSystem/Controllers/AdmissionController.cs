using HospitalManagementSystem.Dtos.Admission;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AdmissionController : ControllerBase
{
    private readonly IAdmissionService _admissionService;

    public AdmissionController(IAdmissionService admissionService)
    {
        _admissionService = admissionService;
    }

    [HttpGet]
    public async Task<ActionResult<List<AdmissionDto>>> GetAdmissions([FromQuery] string? search)
    {
        var admissions = await _admissionService.GetAdmissionsAsync(search);
        return Ok(admissions);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAdmission([FromBody] AdmissionForCreation admissionForCreation)
    {
        var admissionId = await _admissionService.CreateAdmissionAsync(admissionForCreation);
        return CreatedAtAction(nameof(GetAdmissionById), new { id = admissionId }, admissionId);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AdmissionDto>> GetAdmissionById(Guid id)
    {
        var admission = await _admissionService.GetAdmissionByIdAsync(id);
        if (admission == null)
        {
            return NotFound();
        }
        return Ok(admission);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAdmission(Guid id, [FromBody] AdmissionForUpdation admissionForUpdation)
    {
        if (id != admissionForUpdation.Id)
        {
            return BadRequest();
        }

        var result = await _admissionService.UpdateAdmissionAsync(admissionForUpdation);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdmission(Guid id)
    {
        var result = await _admissionService.DeleteAdmissionAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
