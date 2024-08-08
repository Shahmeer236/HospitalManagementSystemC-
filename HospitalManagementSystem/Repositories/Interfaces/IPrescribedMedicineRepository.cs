using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Entities;

public interface IPrescribedMedicineRepository
{
    Task<List<PrescribedMedicine>> GetAllMedicinesAsync();
    Task<PrescribedMedicine> GetMedicineByIdAsync(Guid id);
    Task<Guid> AddMedicineAsync(PrescribedMedicine prescribedMedicine);
    Task<bool> UpdateMedicineAsync(PrescribedMedicine prescribedMedicine);
    Task<bool> DeleteMedicineAsync(Guid id);
}
