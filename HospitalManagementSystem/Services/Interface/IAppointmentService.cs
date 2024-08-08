using HospitalManagementSystem.Dtos.Appointment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAppointmentService
{
    Task<List<AppointmentDto>> GetAppointmentsAsync(string? search);
    Task<Guid> CreateAppointmentAsync(AppointmentForCreation appointmentForCreation);
    Task<AppointmentDto> GetAppointmentByIdAsync(Guid id);
    Task<bool> UpdateAppointmentAsync(AppointmentForUpdation appointmentForUpdation);
    Task<bool> DeleteAppointmentAsync(Guid id);
}
