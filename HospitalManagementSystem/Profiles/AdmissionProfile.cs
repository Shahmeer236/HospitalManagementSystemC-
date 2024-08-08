using AutoMapper;
using HospitalManagementSystem.Dtos.Admission;

namespace HospitalManagementSystem.Profiles
{
    public class AdmissionProfile : Profile
    {
        public AdmissionProfile()
        {

            CreateMap<Admission, AdmissionForListing>();
            CreateMap<Admission, AdmissionDto>();
            CreateMap<AdmissionForCreation, Admission>();
            CreateMap<AdmissionForUpdation, Admission>();

        }
    }
}
