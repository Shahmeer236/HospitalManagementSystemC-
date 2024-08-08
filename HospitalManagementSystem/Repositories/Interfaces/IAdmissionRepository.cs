using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Dtos.Admission;

public interface IAdmissionRepository
{
    Task<List<AdmissionDto>> GetAdmissionsAsync(string? search);
    Task<Guid> AddAdmissionAsync(AdmissionForCreation admissionForCreation);
    Task<AdmissionDto> GetAdmissionByIdAsync(Guid id);
    Task<bool> UpdateAdmissionAsync(AdmissionForUpdation admissionForUpdation);
    Task<bool> DeleteAdmissionAsync(Guid id);
}
