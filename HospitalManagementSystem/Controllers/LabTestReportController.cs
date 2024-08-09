//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using HospitalManagementSystem.Dtos;
//using HospitalManagementSystem.Services;

//[ApiController]
//[Route("api/[controller]")]
//public class LabTestReportController : ControllerBase
//{
//    private readonly ILabTestReportService _labTestReportService;

//    public LabTestReportController(ILabTestReportService labTestReportService)
//    {
//        _labTestReportService = labTestReportService;
//    }

//    [HttpGet]
//    public async Task<ActionResult<List<LabTestReportDto>>> GetAllLabTestReports()
//    {
//        var reports = await _labTestReportService.GetAllLabTestReportsAsync();
//        return Ok(reports);
//    }

//    [HttpGet("{id}")]
//    public async Task<ActionResult<LabTestReportDto>> GetLabTestReportById(Guid id)
//    {
//        var report = await _labTestReportService.GetLabTestReportByIdAsync(id);
//        if (report == null)
//        {
//            return NotFound();
//        }
//        return Ok(report);
//    }

//    [HttpGet("DownloadReport/{id}")]
//    public async Task<ActionResult<LabTestReport>> DownloadLabTestReportById(Guid id)
//    {
//        var report = await _labTestReportService.DownloadLabTestReportById(id);
//        if (report == null)
//        {
//            return NotFound();
//        }
//        return Ok(report);
//    }

//    [HttpPost]
//    public async Task<ActionResult<Guid>> CreateLabTestReport(/*IFormFile formFile*/LabTestReportForCreation labTestReportForCreation)
//    {
//        //LabTestReportForCreation labTestReportForCreation = null;
//        var id = await _labTestReportService.CreateLabTestReportAsync(labTestReportForCreation);
//        return CreatedAtAction(nameof(GetLabTestReportById), new { id }, id);
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> UpdateLabTestReport(Guid id, LabTestReportForUpdation labTestReportForUpdation)
//    {
//        if (id != labTestReportForUpdation.Id)
//        {
//            return BadRequest();
//        }

//        var success = await _labTestReportService.UpdateLabTestReportAsync(labTestReportForUpdation);
//        if (!success)
//        {
//            return NotFound();
//        }

//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteLabTestReport(Guid id)
//    {
//        var success = await _labTestReportService.DeleteLabTestReportAsync(id);
//        if (!success)
//        {
//            return NotFound();
//        }

//        return NoContent();
//    }
//}










using HospitalManagementSystem.Dtos;
using HospitalManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateLabTestReport(LabTestReportForCreation labTestReportForCreation)
    {
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

    [HttpPost("{id}/upload")]
    public async Task<IActionResult> UploadLabTestReport(Guid id, IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();
            var fileName = file.FileName;

            await _labTestReportService.UploadLabTestReportAsync(id, fileBytes, fileName);
        }

        return NoContent();
    }

    [HttpGet("{id}/download")]
    public async Task<IActionResult> DownloadLabTestReport(Guid id)
    {
        try
        {
            var fileBytes = await _labTestReportService.DownloadLabTestReportById(id);
            var report = await _labTestReportService.GetLabTestReportByIdAsync(id);

            return File(fileBytes, "application/octet-stream", report.ReportDetails);
        }
        catch (FileNotFoundException)
        {
            return NotFound();
        }
    }
}
