using HospitalManagementSystem.Dtos.Admission;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AdmissionService : IAdmissionService
{
    private readonly IAdmissionRepository _admissionRepository;

    public AdmissionService(IAdmissionRepository admissionRepository)
    {
        _admissionRepository = admissionRepository;
    }

    public async Task<List<AdmissionDto>> GetAdmissionsAsync(string? search)
    {
        return await _admissionRepository.GetAdmissionsAsync(search);
    }

    public async Task<Guid> CreateAdmissionAsync(AdmissionForCreation admissionForCreation)
    {
        return await _admissionRepository.AddAdmissionAsync(admissionForCreation);
    }

    public async Task<AdmissionDto> GetAdmissionByIdAsync(Guid id)
    {
        return await _admissionRepository.GetAdmissionByIdAsync(id);
    }

    public async Task<bool> UpdateAdmissionAsync(AdmissionForUpdation admissionForUpdation)
    {
        return await _admissionRepository.UpdateAdmissionAsync(admissionForUpdation);
    }

    public async Task<bool> DeleteAdmissionAsync(Guid id)
    {
        return await _admissionRepository.DeleteAdmissionAsync(id);
    }
}
