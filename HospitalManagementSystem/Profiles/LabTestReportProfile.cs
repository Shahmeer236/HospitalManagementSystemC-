using AutoMapper;
using HospitalManagementSystem.Entities;

public class LabTestReportProfile : Profile
{
    public LabTestReportProfile()
    {
        CreateMap<LabTestReport, LabTestReportDto>();
        CreateMap<LabTestReport, LabTestReportForListing>();
        CreateMap<LabTestReportForCreation, LabTestReport>();
        CreateMap<LabTestReportForUpdation, LabTestReport>();
    }
}
