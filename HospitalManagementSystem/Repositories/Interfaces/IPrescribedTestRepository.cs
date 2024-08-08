using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Entities;

public interface IPrescribedTestRepository
{
    Task<List<PrescribedTest>> GetAllTestsAsync();
    Task<PrescribedTest> GetTestByIdAsync(Guid id);
    Task<Guid> AddTestAsync(PrescribedTest prescribedTest);
    Task<bool> UpdateTestAsync(PrescribedTest prescribedTest);
    Task<bool> DeleteTestAsync(Guid id);
}
