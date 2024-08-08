using HospitalManagementSystem.Dtos.Patient;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IPatientServices
    {
        Task<List<PatientDto>> GetPatientAsync(string? search);
        Task<Guid> AddPatientAsync(PatientForCreation patientForCreation);
        Task<PatientDto> GetPatientByIdAsync(Guid id);
        Task<bool> UpdatePatientAsync(PatientForUpdation patientForUpdation);
        Task<bool> DeletePatientById(Guid id);
        Task<PatientDto> GetPatientByEmailAsync(string email);
        Task<PatientDto> GetPatientByNameAsync(string firstName);
    }
}
