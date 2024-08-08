using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Dtos;

public interface IPrescriptionService
{
    Task<List<PrescriptionDto>> GetAllPrescriptionsAsync();
    Task<PrescriptionDto> GetPrescriptionByIdAsync(Guid id);
    Task<Guid> CreatePrescriptionAsync(PrescriptionForCreation prescriptionForCreation);
    Task<bool> UpdatePrescriptionAsync(PrescriptionForUpdation prescriptionForUpdation);
    Task<bool> DeletePrescriptionAsync(Guid id);
}
