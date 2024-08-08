using AutoMapper;
using HospitalManagementSystem.Dtos;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PrescribedTestService : IPrescribedTestService
{
    private readonly IPrescribedTestRepository _prescribedTestRepository;
    private readonly IMapper _mapper;

    public PrescribedTestService(IPrescribedTestRepository prescribedTestRepository, IMapper mapper)
    {
        _prescribedTestRepository = prescribedTestRepository;
        _mapper = mapper;
    }

    public async Task<List<PrescribedTestDto>> GetAllTestsAsync()
    {
        var prescribedTests = await _prescribedTestRepository.GetAllTestsAsync();
        return _mapper.Map<List<PrescribedTestDto>>(prescribedTests);
    }

    public async Task<PrescribedTestDto> GetTestByIdAsync(Guid id)
    {
        var prescribedTest = await _prescribedTestRepository.GetTestByIdAsync(id);
        return _mapper.Map<PrescribedTestDto>(prescribedTest);
    }

    public async Task<Guid> CreateTestAsync(PrescribedTestForCreation prescribedTestForCreation)
    {
        var prescribedTest = _mapper.Map<PrescribedTest>(prescribedTestForCreation);
        return await _prescribedTestRepository.AddTestAsync(prescribedTest);
    }

    public async Task<bool> UpdateTestAsync(PrescribedTestForUpdation prescribedTestForUpdation)
    {
        var prescribedTest = _mapper.Map<PrescribedTest>(prescribedTestForUpdation);
        return await _prescribedTestRepository.UpdateTestAsync(prescribedTest);
    }

    public async Task<bool> DeleteTestAsync(Guid id)
    {
        return await _prescribedTestRepository.DeleteTestAsync(id);
    }
}
