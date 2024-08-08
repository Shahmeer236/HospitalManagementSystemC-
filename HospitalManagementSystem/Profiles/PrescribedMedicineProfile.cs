using AutoMapper;
using HospitalManagementSystem.Entities;

public class PrescribedMedicineProfile : Profile
{
    public PrescribedMedicineProfile()
    {
        CreateMap<PrescribedMedicine, PrescribedMedicineDto>();
        CreateMap<PrescribedMedicine, PrescribedMedicineForListing>();
        CreateMap<PrescribedMedicineForCreation, PrescribedMedicine>();
        CreateMap<PrescribedMedicineForUpdation, PrescribedMedicine>();
    }
}
