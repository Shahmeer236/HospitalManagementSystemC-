using AutoMapper;
using HospitalManagementSystem.Dtos.Doctor;

namespace HospitalManagementSystem.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {

            CreateMap<Doctor, DoctorForListing>();
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorForCreation, Doctor>();
            CreateMap<DoctorForUpdation, Doctor>();

        }
    }
}
