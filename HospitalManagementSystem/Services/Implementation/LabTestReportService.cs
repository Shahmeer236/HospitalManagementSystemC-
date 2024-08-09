//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using AutoMapper;
//using HospitalManagementSystem.Dtos;
//using HospitalManagementSystem.Entities;
//using HospitalManagementSystem.Repositories;

//public class LabTestReportService : ILabTestReportService
//{
//    private readonly ILabTestReportRepository _labTestReportRepository;
//    private readonly IMapper _mapper;

//    public LabTestReportService(ILabTestReportRepository labTestReportRepository, IMapper mapper)
//    {
//        _labTestReportRepository = labTestReportRepository;
//        _mapper = mapper;
//    }

//    public async Task<List<LabTestReportDto>> GetAllLabTestReportsAsync()
//    {
//        var reports = await _labTestReportRepository.GetAllLabTestReportsAsync();
//        return _mapper.Map<List<LabTestReportDto>>(reports);
//    }

//    public async Task<LabTestReportDto> GetLabTestReportByIdAsync(Guid id)
//    {
//        var report = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
//        return _mapper.Map<LabTestReportDto>(report);
//    }

//    public async Task<Guid> CreateLabTestReportAsync(LabTestReportForCreation labTestReportForCreation)
//    {
//        var report = _mapper.Map<LabTestReport>(labTestReportForCreation);
//        return await _labTestReportRepository.AddLabTestReportAsync(report);
//    }

//    public async Task<bool> UpdateLabTestReportAsync(LabTestReportForUpdation labTestReportForUpdation)
//    {
//        var report = _mapper.Map<LabTestReport>(labTestReportForUpdation);
//        return await _labTestReportRepository.UpdateLabTestReportAsync(report);
//    }

//    public async Task<bool> DeleteLabTestReportAsync(Guid id)
//    {
//        return await _labTestReportRepository.DeleteLabTestReportAsync(id);
//    }

//    public async Task<LabTestReport> DownloadLabTestReportById(Guid id)
//    {
//        return await _labTestReportRepository.DownloadLabTestReportById(id);
//    }
//}





//using AutoMapper;
//using HospitalManagementSystem.Dtos;
//using HospitalManagementSystem.Entities;
//using HospitalManagementSystem.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//public class LabTestReportService : ILabTestReportService
//{
//    private readonly ILabTestReportRepository _labTestReportRepository;
//    private readonly IFileStorageService _fileStorageService;
//    private readonly IMapper _mapper;

//    public LabTestReportService(ILabTestReportRepository labTestReportRepository, IFileStorageService fileStorageService, IMapper mapper)
//    {
//        _labTestReportRepository = labTestReportRepository;
//        _fileStorageService = fileStorageService;
//        _mapper = mapper;
//    }

//    public async Task<List<LabTestReportDto>> GetAllLabTestReportsAsync()
//    {
//        var reports = await _labTestReportRepository.GetAllLabTestReportsAsync();
//        return _mapper.Map<List<LabTestReportDto>>(reports);
//    }

//    public async Task<LabTestReportDto> GetLabTestReportByIdAsync(Guid id)
//    {
//        var report = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
//        return _mapper.Map<LabTestReportDto>(report);
//    }

//    public async Task<Guid> CreateLabTestReportAsync(LabTestReportForCreation labTestReportForCreation)
//    {
//        var report = _mapper.Map<LabTestReport>(labTestReportForCreation);
//        return await _labTestReportRepository.AddLabTestReportAsync(report);
//    }

//    public async Task<bool> UpdateLabTestReportAsync(LabTestReportForUpdation labTestReportForUpdation)
//    {
//        var report = _mapper.Map<LabTestReport>(labTestReportForUpdation);
//        return await _labTestReportRepository.UpdateLabTestReportAsync(report);
//    }

//    public async Task<bool> DeleteLabTestReportAsync(Guid id)
//    {
//        var report = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
//        if (report == null)
//        {
//            return false;
//        }

//        _fileStorageService.DeleteFile(report.ReportDetails);
//        return await _labTestReportRepository.DeleteLabTestReportAsync(id);
//    }

//    public async Task UploadLabTestReportAsync(Guid id, byte[] fileBytes, string fileName)
//    {
//        var labTestReport = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
//        if (labTestReport == null)
//        {
//            throw new FileNotFoundException("Lab test report not found.");
//        }

//        var filePath = await _fileStorageService.SaveFileAsync(fileBytes, fileName);
//        labTestReport.ReportDetails = filePath;

//        await _labTestReportRepository.UpdateLabTestReportAsync(labTestReport);
//    }




//    public async Task<byte[]> DownloadLabTestReportById(Guid id)
//    {
//        var report = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
//        if (report == null || string.IsNullOrEmpty(report.ReportDetails))
//        {
//            throw new FileNotFoundException("Lab test report not found.");
//        }

//        return await _fileStorageService.DownloadFileAsync(report.ReportDetails);
//    }
//}






//using AutoMapper;
//using HospitalManagementSystem.Dtos;
//using HospitalManagementSystem.Entities;
//using HospitalManagementSystem.Repositories;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//public class LabTestReportService : ILabTestReportService
//{
//    private readonly ILabTestReportRepository _labTestReportRepository;
//    private readonly IFileStorageService _fileStorageService;
//    private readonly IMapper _mapper;

//    public LabTestReportService(ILabTestReportRepository labTestReportRepository, IFileStorageService fileStorageService, IMapper mapper)
//    {
//        _labTestReportRepository = labTestReportRepository;
//        _fileStorageService = fileStorageService;
//        _mapper = mapper;
//    }

//    public async Task<List<LabTestReportDto>> GetAllLabTestReportsAsync()
//    {
//        var reports = await _labTestReportRepository.GetAllLabTestReportsAsync();
//        return _mapper.Map<List<LabTestReportDto>>(reports);
//    }

//    public async Task<LabTestReportDto> GetLabTestReportByIdAsync(Guid id)
//    {
//        var report = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
//        return _mapper.Map<LabTestReportDto>(report);
//    }

//    public async Task<Guid> CreateLabTestReportAsync(LabTestReportForCreation labTestReportForCreation)
//    {
//        var report = _mapper.Map<LabTestReport>(labTestReportForCreation);
//        return await _labTestReportRepository.AddLabTestReportAsync(report);
//    }

//    public async Task<bool> UpdateLabTestReportAsync(LabTestReportForUpdation labTestReportForUpdation)
//    {
//        var report = _mapper.Map<LabTestReport>(labTestReportForUpdation);
//        return await _labTestReportRepository.UpdateLabTestReportAsync(report);
//    }

//    public async Task<bool> DeleteLabTestReportAsync(Guid id)
//    {
//        var report = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
//        if (report == null)
//        {
//            return false;
//        }

//        _fileStorageService.DeleteFile(report.ReportDetails);
//        return await _labTestReportRepository.DeleteLabTestReportAsync(id);
//    }

//    public async Task UploadLabTestReportAsync(Guid id, IFormFile file)
//    {
//        var labTestReport = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
//        if (labTestReport == null)
//        {
//            throw new FileNotFoundException("Lab test report not found.");
//        }

//        var filePath = await _fileStorageService.SaveFileAsync(file);
//        labTestReport.ReportDetails = filePath;

//        await _labTestReportRepository.UpdateLabTestReportAsync(labTestReport);
//    }

//    public async Task<byte[]> DownloadLabTestReportById(Guid id)
//    {
//        var report = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
//        if (report == null || string.IsNullOrEmpty(report.ReportDetails))
//        {
//            throw new FileNotFoundException("Lab test report not found.");
//        }

//        return await _fileStorageService.DownloadFileAsync(report.ReportDetails);
//    }
//}














using AutoMapper;
using HospitalManagementSystem.Dtos;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LabTestReportService : ILabTestReportService
{
    private readonly ILabTestReportRepository _labTestReportRepository;
    private readonly IFileStorageService _fileStorageService;
    private readonly IMapper _mapper;

    public LabTestReportService(ILabTestReportRepository labTestReportRepository, IFileStorageService fileStorageService, IMapper mapper)
    {
        _labTestReportRepository = labTestReportRepository;
        _fileStorageService = fileStorageService;
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
        var report = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
        if (report == null)
        {
            return false;
        }

        _fileStorageService.DeleteFile(report.ReportDetails);
        return await _labTestReportRepository.DeleteLabTestReportAsync(id);
    }

    public async Task UploadLabTestReportAsync(Guid id, byte[] fileBytes, string fileName)
    {
        var labTestReport = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
        if (labTestReport == null)
        {
            throw new FileNotFoundException("Lab test report not found.");
        }

        var filePath = await _fileStorageService.SaveFileAsync(fileBytes, fileName);
        labTestReport.ReportDetails = filePath;

        await _labTestReportRepository.UpdateLabTestReportAsync(labTestReport);
    }


    public async Task<byte[]> DownloadLabTestReportById(Guid id)
    {
        var report = await _labTestReportRepository.GetLabTestReportByIdAsync(id);
        if (report == null || string.IsNullOrEmpty(report.ReportDetails))
        {
            throw new FileNotFoundException("Lab test report not found.");
        }

        return await _fileStorageService.DownloadFileAsync(report.ReportDetails);
    }
}
