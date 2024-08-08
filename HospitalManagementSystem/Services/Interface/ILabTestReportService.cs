using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Dtos;

public interface ILabTestReportService
{
    Task<List<LabTestReportDto>> GetAllLabTestReportsAsync();
    Task<LabTestReportDto> GetLabTestReportByIdAsync(Guid id);
    Task<Guid> CreateLabTestReportAsync(LabTestReportForCreation labTestReportForCreation);
    Task<bool> UpdateLabTestReportAsync(LabTestReportForUpdation labTestReportForUpdation);
    Task<bool> DeleteLabTestReportAsync(Guid id);

    Task<LabTestReport> DownloadLabTestReportById(Guid id);
}
