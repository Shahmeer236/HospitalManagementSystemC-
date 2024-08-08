using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Dtos;

public interface IPrescribedTestService
{
    Task<List<PrescribedTestDto>> GetAllTestsAsync();
    Task<PrescribedTestDto> GetTestByIdAsync(Guid id);
    Task<Guid> CreateTestAsync(PrescribedTestForCreation prescribedTestForCreation);
    Task<bool> UpdateTestAsync(PrescribedTestForUpdation prescribedTestForUpdation);
    Task<bool> DeleteTestAsync(Guid id);
}
