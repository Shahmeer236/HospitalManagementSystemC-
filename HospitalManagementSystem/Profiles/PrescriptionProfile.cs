using AutoMapper;
using HospitalManagementSystem.Entities;

public class PrescriptionProfile : Profile
{
    public PrescriptionProfile()
    {
        CreateMap<Prescription, PrescriptionDto>();
        CreateMap<Prescription, PrescriptionForListing>();
        CreateMap<PrescriptionForCreation, Prescription>();
        CreateMap<PrescriptionForUpdation, Prescription>();
    }
}
