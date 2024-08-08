using AutoMapper;
using HospitalManagementSystem.Dtos.MedicalRecord;

namespace HospitalManagementSystem.Profiles
{
    public class MedicalRecordProfile :Profile
    {
        public MedicalRecordProfile()
        {

            CreateMap<MedicalRecord, MedicalRecordForListing>();
            CreateMap<MedicalRecord, MedicalRecordDto>();
            CreateMap<MedicalRecordForCreation, MedicalRecord>();
            CreateMap<MedicalRecordForUpdation, MedicalRecord>();

        }
    }
}
