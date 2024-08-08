using AutoMapper;
using HospitalManagementSystem.Dtos.Patient;

namespace HospitalManagementSystem.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {

            CreateMap<Patient, PatientForListing>();
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientForCreation, Patient>();
            CreateMap<PatientForUpdation, Patient>();

        }
    }
}
