using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HospitalManagementSystem.Dtos;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repositories;

public class LabTestReportService : ILabTestReportService
{
    private readonly ILabTestReportRepository _labTestReportRepository;
    private readonly IMapper _mapper;

    public LabTestReportService(ILabTestReportRepository labTestReportRepository, IMapper mapper)
    {
        _labTestReportRepository = labTestReportRepository;
        _mapper = mapper;
    }

    public async Task<List<LabTestReportDto>> GetAllLabTestReportsAsync()
    {
        var reports = await _labTestReportRepository.GetAllLabTestReportsAsync();
        return _mapper.Map<List<LabTestReportDto>>(reports);
    }

    public async Task<LabTestReportDto> GetLabTestReportByIdAsync(Guid id)
    {
        var report = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
        return _mapper.Map<LabTestReportDto>(report);
    }

    public async Task<Guid> CreateLabTestReportAsync(LabTestReportForCreation labTestReportForCreation)
    {
        var report = _mapper.Map<LabTestReport>(labTestReportForCreation);
        return await _labTestReportRepository.AddLabTestReportAsync(report);
    }

    public async Task<bool> UpdateLabTestReportAsync(LabTestReportForUpdation labTestReportForUpdation)
    {
        var report = _mapper.Map<LabTestReport>(labTestReportForUpdation);
        return await _labTestReportRepository.UpdateLabTestReportAsync(report);
    }

    public async Task<bool> DeleteLabTestReportAsync(Guid id)
    {
        return await _labTestReportRepository.DeleteLabTestReportAsync(id);
    }

    public async Task<LabTestReport> DownloadLabTestReportById(Guid id)
    {
        return await _labTestReportRepository.DownloadLabTestReportById(id);
    }
}
