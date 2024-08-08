using AutoMapper;
using HospitalManagementSystem.Entities;

public class PrescribedTestProfile : Profile
{
    public PrescribedTestProfile()
    {
        CreateMap<PrescribedTest, PrescribedTestDto>();
        CreateMap<PrescribedTest, PrescribedTestForListing>();
        CreateMap<PrescribedTestForCreation, PrescribedTest>();
        CreateMap<PrescribedTestForUpdation, PrescribedTest>();
    }
}
