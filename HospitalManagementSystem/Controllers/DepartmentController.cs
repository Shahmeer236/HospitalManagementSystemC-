using AutoMapper;
using HospitalManagementSystem.Dtos.Department;
using HospitalManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentServices _departmentServices;

        public DepartmentController(IMapper mapper, IDepartmentServices departmentServices)
        {
            _mapper = mapper;
            _departmentServices = departmentServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentForListing>>> GetDepartments([FromQuery] string? search)
        {
            var departments = await _departmentServices.GetDepartmentAsync(search);
            return Ok(departments);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddDepartment(DepartmentForCreation departmentForCreation)
        {
            var departmentId = await _departmentServices.AddDepartmentAsync(departmentForCreation);
            return Ok(departmentId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentById(Guid id)
        {
            var department = await _departmentServices.GetDepartmentByIdAsync(id);
            return Ok(department);
        }

        [HttpPut]
        public async Task<ActionResult<DepartmentDto>> UpdateDepartment(DepartmentForUpdation departmentForUpdation)
        {
            var updatedDepartment = await _departmentServices.UpdateDepartmentAsync(departmentForUpdation);
            return Ok(updatedDepartment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(Guid id)
        {
            var result = await _departmentServices.DeleteDepartmentAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
