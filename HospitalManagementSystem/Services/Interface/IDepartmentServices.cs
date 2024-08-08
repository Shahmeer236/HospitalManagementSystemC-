using HospitalManagementSystem.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IDepartmentServices
    {
        Task<IEnumerable<DepartmentForListing>> GetDepartmentAsync(string? search);
        Task<Guid> AddDepartmentAsync(DepartmentForCreation departmentForCreation);
        Task<DepartmentDto> GetDepartmentByIdAsync(Guid id);
        Task<DepartmentDto> UpdateDepartmentAsync(DepartmentForUpdation departmentForUpdation);
        Task<bool> DeleteDepartmentAsync(Guid id);
    }
}
