using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync(string? search);
        Task<Guid> AddDoctorAsync(Doctor doctor);
        Task<Doctor> GetDoctorByIdAsync(Guid id);
        Task UpdateDoctorAsync(Doctor doctor);
        Task<bool> DeleteDoctorAsync(Guid id);
    }
}
