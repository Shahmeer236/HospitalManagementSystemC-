using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Dtos;
using HospitalManagementSystem.Services;

[ApiController]
[Route("api/[controller]")]
public class LabTestReportController : ControllerBase
{
    private readonly ILabTestReportService _labTestReportService;

    public LabTestReportController(ILabTestReportService labTestReportService)
    {
        _labTestReportService = labTestReportService;
    }

    [HttpGet]
    public async Task<ActionResult<List<LabTestReportDto>>> GetAllLabTestReports()
    {
        var reports = await _labTestReportService.GetAllLabTestReportsAsync();
        return Ok(reports);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LabTestReportDto>> GetLabTestReportById(Guid id)
    {
        var report = await _labTestReportService.GetLabTestReportByIdAsync(id);
        if (report == null)
        {
            return NotFound();
        }
        return Ok(report);
    }

    [HttpGet("DownloadReport/{id}")]
    public async Task<ActionResult<LabTestReport>> DownloadLabTestReportById(Guid id)
    {
        var report = await _labTestReportService.DownloadLabTestReportById(id);
        if (report == null)
        {
            return NotFound();
        }
        return Ok(report);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateLabTestReport(IFormFile formFile)
    {
        LabTestReportForCreation labTestReportForCreation = null;
        var id = await _labTestReportService.CreateLabTestReportAsync(labTestReportForCreation);
        return CreatedAtAction(nameof(GetLabTestReportById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLabTestReport(Guid id, LabTestReportForUpdation labTestReportForUpdation)
    {
        if (id != labTestReportForUpdation.Id)
        {
            return BadRequest();
        }

        var success = await _labTestReportService.UpdateLabTestReportAsync(labTestReportForUpdation);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLabTestReport(Guid id)
    {
        var success = await _labTestReportService.DeleteLabTestReportAsync(id);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}
