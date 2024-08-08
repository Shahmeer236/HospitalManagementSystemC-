using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Dtos;
using HospitalManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PrescribedTestController : ControllerBase
{
    private readonly IPrescribedTestService _prescribedTestService;

    public PrescribedTestController(IPrescribedTestService prescribedTestService)
    {
        _prescribedTestService = prescribedTestService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PrescribedTestDto>>> GetAllTests()
    {
        var tests = await _prescribedTestService.GetAllTestsAsync();
        return Ok(tests);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PrescribedTestDto>> GetTestById(Guid id)
    {
        var test = await _prescribedTestService.GetTestByIdAsync(id);
        if (test == null)
        {
            return NotFound();
        }
        return Ok(test);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateTest([FromBody] PrescribedTestForCreation prescribedTestForCreation)
    {
        var id = await _prescribedTestService.CreateTestAsync(prescribedTestForCreation);
        return CreatedAtAction(nameof(GetTestById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTest(Guid id, [FromBody] PrescribedTestForUpdation prescribedTestForUpdation)
    {
        if (id != prescribedTestForUpdation.Id)
        {
            return BadRequest();
        }

        var result = await _prescribedTestService.UpdateTestAsync(prescribedTestForUpdation);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTest(Guid id)
    {
        var result = await _prescribedTestService.DeleteTestAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
