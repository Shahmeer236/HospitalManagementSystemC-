using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Dtos;

public interface IPrescribedMedicineService
{
    Task<List<PrescribedMedicineDto>> GetAllMedicinesAsync();
    Task<PrescribedMedicineDto> GetMedicineByIdAsync(Guid id);
    Task<Guid> CreateMedicineAsync(PrescribedMedicineForCreation prescribedMedicineForCreation);
    Task<bool> UpdateMedicineAsync(PrescribedMedicineForUpdation prescribedMedicineForUpdation);
    Task<bool> DeleteMedicineAsync(Guid id);
}
