//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using HospitalManagementSystem.Dtos;

//public interface ILabTestReportService
//{
//    Task<List<LabTestReportDto>> GetAllLabTestReportsAsync();
//    Task<LabTestReportDto> GetLabTestReportByIdAsync(Guid id);
//    Task<Guid> CreateLabTestReportAsync(LabTestReportForCreation labTestReportForCreation);
//    Task<bool> UpdateLabTestReportAsync(LabTestReportForUpdation labTestReportForUpdation);
//    Task<bool> DeleteLabTestReportAsync(Guid id);

//    // Add this method to the interface
//    Task UploadLabTestReportAsync(Guid id, byte[] fileBytes, string fileName);

//    //Task<LabTestReport> DownloadLabTestReportById(Guid id);
//    Task<byte[]> DownloadLabTestReportById(Guid id); // This should be in the ILabTestReportService interface

//}




using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Dtos;
using Microsoft.AspNetCore.Http;

public interface ILabTestReportService
{
    Task<List<LabTestReportDto>> GetAllLabTestReportsAsync();
    Task<LabTestReportDto> GetLabTestReportByIdAsync(Guid id);
    Task<Guid> CreateLabTestReportAsync(LabTestReportForCreation labTestReportForCreation);
    Task<bool> UpdateLabTestReportAsync(LabTestReportForUpdation labTestReportForUpdation);
    Task<bool> DeleteLabTestReportAsync(Guid id);
    // Update method signature to use IFormFile
    Task UploadLabTestReportAsync(Guid id, byte[] fileBytes, string fileName);
    Task<byte[]> DownloadLabTestReportById(Guid id);
}
