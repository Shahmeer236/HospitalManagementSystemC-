using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Entities;

public interface ILabTestReportRepository
{
    Task<List<LabTestReport>> GetAllLabTestReportsAsync();
    Task<LabTestReport> GetLabTestReportByIdAsync(Guid id);
    Task<Guid> AddLabTestReportAsync(LabTestReport labTestReport);
    Task<bool> UpdateLabTestReportAsync(LabTestReport labTestReport);
    Task<bool> DeleteLabTestReportAsync(Guid id);

    Task<LabTestReport> DownloadLabTestReportById(Guid id);
}
