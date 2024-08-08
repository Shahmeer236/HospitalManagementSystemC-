using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Entities;

public class PrescribedTestRepository : IPrescribedTestRepository
{
    private readonly HospitalManagementSystemDbContext _context;

    public PrescribedTestRepository(HospitalManagementSystemDbContext context)
    {
        _context = context;
    }

    public async Task<List<PrescribedTest>> GetAllTestsAsync()
    {
        return await _context.PrescribedTests.ToListAsync();
    }

    public async Task<PrescribedTest> GetTestByIdAsync(Guid id)
    {
        return await _context.PrescribedTests.FindAsync(id);
    }

    public async Task<Guid> AddTestAsync(PrescribedTest prescribedTest)
    {
        _context.PrescribedTests.Add(prescribedTest);
        await _context.SaveChangesAsync();
        return prescribedTest.Id;
    }

    public async Task<bool> UpdateTestAsync(PrescribedTest prescribedTest)
    {
        _context.PrescribedTests.Update(prescribedTest);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }

    public async Task<bool> DeleteTestAsync(Guid id)
    {
        var test = await _context.PrescribedTests.FindAsync(id);
        if (test == null)
        {
            return false;
        }
        _context.PrescribedTests.Remove(test);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }
}
