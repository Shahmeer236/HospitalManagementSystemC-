using AutoMapper;
using HospitalManagementSystem.Dtos.Department;

namespace HospitalManagementSystem.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {

            CreateMap<Department, DepartmentForListing>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentForCreation, Department>();
            CreateMap<DepartmentForUpdation, Department>();

        }
    }
}
