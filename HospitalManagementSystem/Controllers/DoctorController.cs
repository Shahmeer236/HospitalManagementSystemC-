using AutoMapper;
using HospitalManagementSystem.Dtos.Doctor;
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
  //  [Authorize(Policy = "DoctorOnly")]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorServices _doctorServices;

        public DoctorController(IMapper mapper, IDoctorServices doctorServices)
        {
            _mapper = mapper;
            _doctorServices = doctorServices;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddDoctor(DoctorForCreation doctorForCreation)
        {
            var doctorId = await _doctorServices.AddDoctorAsync(doctorForCreation);
            return Ok(doctorId);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors([FromQuery] string? search)
        {
            var doctors = await _doctorServices.GetDoctorsAsync(search);
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctorByIdAsync(Guid id)
        {
            var doctor = await _doctorServices.GetDoctorByIdAsync(id);
            return Ok(doctor);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDoctor(DoctorForUpdation doctorForUpdation)
        {
            await _doctorServices.UpdateDoctorAsync(doctorForUpdation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(Guid id)
        {
            var result = await _doctorServices.DeleteDoctorAsync(id);
            if (!result)
            {
                return NotFound(id);
            }

            return NoContent();
        }
    }
}
