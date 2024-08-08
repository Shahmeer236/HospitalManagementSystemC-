using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Dtos;
using HospitalManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PrescribedMedicineController : ControllerBase
{
    private readonly IPrescribedMedicineService _prescribedMedicineService;

    public PrescribedMedicineController(IPrescribedMedicineService prescribedMedicineService)
    {
        _prescribedMedicineService = prescribedMedicineService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PrescribedMedicineDto>>> GetAllMedicines()
    {
        var medicines = await _prescribedMedicineService.GetAllMedicinesAsync();
        return Ok(medicines);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PrescribedMedicineDto>> GetMedicineById(Guid id)
    {
        var medicine = await _prescribedMedicineService.GetMedicineByIdAsync(id);
        if (medicine == null)
        {
            return NotFound();
        }
        return Ok(medicine);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateMedicine([FromBody] PrescribedMedicineForCreation prescribedMedicineForCreation)
    {
        var id = await _prescribedMedicineService.CreateMedicineAsync(prescribedMedicineForCreation);
        return CreatedAtAction(nameof(GetMedicineById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateMedicine(Guid id, [FromBody] PrescribedMedicineForUpdation prescribedMedicineForUpdation)
    {
        if (id != prescribedMedicineForUpdation.Id)
        {
            return BadRequest();
        }

        var result = await _prescribedMedicineService.UpdateMedicineAsync(prescribedMedicineForUpdation);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMedicine(Guid id)
    {
        var result = await _prescribedMedicineService.DeleteMedicineAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
