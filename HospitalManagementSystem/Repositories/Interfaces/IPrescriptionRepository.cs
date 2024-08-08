using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Entities;

public interface IPrescriptionRepository
{
    Task<List<Prescription>> GetAllPrescriptionsAsync();
    Task<Prescription> GetPrescriptionByIdAsync(Guid id);
    Task<Guid> AddPrescriptionAsync(Prescription prescription);
    Task<bool> UpdatePrescriptionAsync(Prescription prescription);
    Task<bool> DeletePrescriptionAsync(Guid id);
}
