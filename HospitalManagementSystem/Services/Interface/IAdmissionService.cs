using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Dtos.Admission;

public interface IAdmissionService
{
    Task<List<AdmissionDto>> GetAdmissionsAsync(string? search);
    Task<Guid> CreateAdmissionAsync(AdmissionForCreation admissionForCreation);
    Task<AdmissionDto> GetAdmissionByIdAsync(Guid id);
    Task<bool> UpdateAdmissionAsync(AdmissionForUpdation admissionForUpdation);
    Task<bool> DeleteAdmissionAsync(Guid id);
}
