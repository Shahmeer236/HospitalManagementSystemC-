
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync(string? search);
        Task<Guid> AddDepartmentAsync(Department department);
        Task<Department> GetDepartmentByIdAsync(Guid id);
        Task UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentAsync(Guid id);
    }
}
