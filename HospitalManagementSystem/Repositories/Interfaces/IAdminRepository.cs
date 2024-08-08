using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Model;


namespace HospitalManagementSystem.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAdminsAsync(string? search);
        Task<Guid> AddAdminAsync(Admin admin);
        Task<Admin> GetAdminByIdAsync(Guid id);
        Task UpdateAdminAsync(Admin admin);
        Task<bool> DeleteAdminAsync(Guid id);
    }
}
