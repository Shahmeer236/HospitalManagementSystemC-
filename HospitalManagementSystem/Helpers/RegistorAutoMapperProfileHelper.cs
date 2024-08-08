using AutoMapper;
using HospitalManagementSystem.Profiles;

namespace HospitalManagementSystem.Helpers
{
    public class RegistorAutoMapperProfileHelper
    {
        public static IMapper RegistorProfiles(IServiceProvider provider)
        {
            return new MapperConfiguration(cfg =>
            {
                // Add multiple profiles here
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<RoomProfile>();
                cfg.AddProfile<PatientProfile>();
                cfg.AddProfile<MedicalRecordProfile>();
                cfg.AddProfile<DoctorProfile>();
                cfg.AddProfile<DepartmentProfile>();
                cfg.AddProfile<BillProfile>();
                cfg.AddProfile<AppointmentProfile>();
                cfg.AddProfile<AdmissionProfile>();
                cfg.AddProfile<RoomProfile>();
                cfg.AddProfile<PrescriptionProfile>();
                cfg.AddProfile<PrescribedMedicineProfile>();
                cfg.AddProfile<PrescribedTestProfile>();
                cfg.AddProfile<LabTestReportProfile>();
                cfg.AddProfile<BillProfile>();










                // If you need to create services for profiles using the service provider
                cfg.ConstructServicesUsing(type => ActivatorUtilities.CreateInstance(provider, type));
            }).CreateMapper();
        }
    }
}
