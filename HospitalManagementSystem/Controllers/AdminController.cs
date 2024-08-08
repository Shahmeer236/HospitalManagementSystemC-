using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Dtos.Admin;
using HospitalManagementSystem.Services.Interfaces;

namespace HospitalManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminDto>>> GetAdmins([FromQuery] string? search)
        {
            var admins = await _adminService.GetAdminsAsync(search);
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDto>> GetAdminById(Guid id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAdmin(AdminForCreation adminForCreation)
        {
            try
            {
                var adminId = await _adminService.CreateAdminAsync(adminForCreation);
                return CreatedAtAction(nameof(GetAdminById), new { id = adminId }, adminId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(Guid id, AdminForUpdation adminForUpdation)
        {
            if (id != adminForUpdation.Id)
            {
                return BadRequest();
            }

            var updated = await _adminService.UpdateAdminAsync(adminForUpdation);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(Guid id)
        {
            var deleted = await _adminService.DeleteAdminAsync(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
