using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Entities;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly HospitalManagementSystemDbContext _context;

    public PrescriptionRepository(HospitalManagementSystemDbContext context)
    {
        _context = context;
    }

    public async Task<List<Prescription>> GetAllPrescriptionsAsync()
    {
        return await _context.Prescriptions
                             .Include(p => p.Doctor)
                             .Include(p => p.Patient)
                             .Include(p => p.PrescribedMedicine) // Include optional medicine
                             .Include(p => p.PrescribedTest) // Include optional test
                             .ToListAsync();
    }

    public async Task<Prescription> GetPrescriptionByIdAsync(Guid id)
    {
        return await _context.Prescriptions
                             .Include(p => p.Doctor)
                             .Include(p => p.Patient)
                             .Include(p => p.PrescribedMedicine) // Include optional medicine
                             .Include(p => p.PrescribedTest) // Include optional test
                             .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Guid> AddPrescriptionAsync(Prescription prescription)
    {
        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
        return prescription.Id;
    }

    public async Task<bool> UpdatePrescriptionAsync(Prescription prescription)
    {
        _context.Prescriptions.Update(prescription);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }

    public async Task<bool> DeletePrescriptionAsync(Guid id)
    {
        var prescription = await _context.Prescriptions.FindAsync(id);
        if (prescription == null)
        {
            return false;
        }
        _context.Prescriptions.Remove(prescription);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }
}
