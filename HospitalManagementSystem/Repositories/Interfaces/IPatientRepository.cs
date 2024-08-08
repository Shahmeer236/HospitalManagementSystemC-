using HospitalManagementSystem.Dtos.Patient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<PatientDto>> GetPatientAsync(string? search);
        Task<Guid> AddPatientAsync(PatientForCreation patientForCreation);
        Task<PatientDto> GetPatientByIdAsync(Guid id);
        Task<bool> UpdatePatientAsync(PatientForUpdation patientForUpdation);
        Task<bool> DeletePatientAsync(Guid id);
        Task<PatientDto> GetPatientByEmailAsync(string email);
        Task<PatientDto> GetPatientByNameAsync(string firstName);

        // Optionally, add these if needed
        Task<bool> UserIdValidator(Guid id);
        Task<bool> UserRoleValidator(string role);
    }
}
