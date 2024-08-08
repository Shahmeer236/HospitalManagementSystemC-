using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Dtos.Admin;

namespace HospitalManagementSystem.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<AdminDto>> GetAdminsAsync(string? search);
        Task<Guid> CreateAdminAsync(AdminForCreation adminForCreation);
        Task<AdminDto> GetAdminByIdAsync(Guid id);
        Task<bool> UpdateAdminAsync(AdminForUpdation adminForUpdation);
        Task<bool> DeleteAdminAsync(Guid id);
    }
}
