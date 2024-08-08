using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Entities;

public class PrescribedMedicineRepository : IPrescribedMedicineRepository
{
    private readonly HospitalManagementSystemDbContext _context;

    public PrescribedMedicineRepository(HospitalManagementSystemDbContext context)
    {
        _context = context;
    }

    public async Task<List<PrescribedMedicine>> GetAllMedicinesAsync()
    {
        return await _context.PrescribedMedicines.ToListAsync();
    }

    public async Task<PrescribedMedicine> GetMedicineByIdAsync(Guid id)
    {
        return await _context.PrescribedMedicines.FindAsync(id);
    }

    public async Task<Guid> AddMedicineAsync(PrescribedMedicine prescribedMedicine)
    {
        _context.PrescribedMedicines.Add(prescribedMedicine);
        await _context.SaveChangesAsync();
        return prescribedMedicine.Id;
    }

    public async Task<bool> UpdateMedicineAsync(PrescribedMedicine prescribedMedicine)
    {
        _context.PrescribedMedicines.Update(prescribedMedicine);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }

    public async Task<bool> DeleteMedicineAsync(Guid id)
    {
        var medicine = await _context.PrescribedMedicines.FindAsync(id);
        if (medicine == null)
        {
            return false;
        }
        _context.PrescribedMedicines.Remove(medicine);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }
}
