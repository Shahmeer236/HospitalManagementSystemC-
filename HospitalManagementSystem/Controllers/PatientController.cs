using AutoMapper;
using HospitalManagementSystem.Dtos.Patient;
using HospitalManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "PatientOnly")]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientServices _patientServices;

        public PatientController(IMapper mapper, IPatientServices patientServices)
        {
            _mapper = mapper;
            _patientServices = patientServices;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddPatient(PatientForCreation patientForCreation)
        {
            var patientId = await _patientServices.AddPatientAsync(patientForCreation);
            return CreatedAtAction(nameof(GetPatientByIdAsync), new { id = patientId }, patientId);
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientDto>>> GetPatients([FromQuery] string? search)
        {
            var patients = await _patientServices.GetPatientAsync(search);
            return Ok(patients);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<PatientDto>> GetPatientByEmail(string email)
        {
            var patient = await _patientServices.GetPatientByEmailAsync(email);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<PatientDto>> GetPatientByIdAsync(Guid id)
        {
            var patient = await _patientServices.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpGet("name/{firstName}")]
        public async Task<ActionResult<PatientDto>> GetPatientByNameAsync(string firstName)
        {
            var patient = await _patientServices.GetPatientByNameAsync(firstName);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient(PatientForUpdation patientForUpdation)
        {
            var success = await _patientServices.UpdatePatientAsync(patientForUpdation);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientById(Guid id)
        {
            var success = await _patientServices.DeletePatientById(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
