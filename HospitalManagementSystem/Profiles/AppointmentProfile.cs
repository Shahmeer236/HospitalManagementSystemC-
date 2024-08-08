using AutoMapper;
using HospitalManagementSystem.Dtos.Appointment;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<Appointment, AppointmentDto>();
        CreateMap<AppointmentForCreation, Appointment>();
        CreateMap<AppointmentForUpdation, Appointment>();
        CreateMap<Appointment, AppointmentForUpdation>();
    }
}
