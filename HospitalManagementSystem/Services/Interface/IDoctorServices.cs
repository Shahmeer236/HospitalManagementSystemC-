using HospitalManagementSystem.Dtos.Doctor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IDoctorServices
    {
        Task<Guid> AddDoctorAsync(DoctorForCreation doctorForCreation);
        Task<DoctorDto> GetDoctorByIdAsync(Guid id);
        Task UpdateDoctorAsync(DoctorForUpdation doctorForUpdation);
        Task<bool> DeleteDoctorAsync(Guid id);
        Task<IEnumerable<DoctorDto>> GetDoctorsAsync(string? search);
    }
}
