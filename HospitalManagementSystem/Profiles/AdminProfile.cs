using AutoMapper;
using HospitalManagementSystem.Dtos.Admin;
using HospitalManagementSystem.Model;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<Admin, AdminDto>();
        CreateMap<Admin, AdminForListing>();
        CreateMap<AdminForCreation, Admin>();
        CreateMap<AdminForUpdation, Admin>();
    }
}