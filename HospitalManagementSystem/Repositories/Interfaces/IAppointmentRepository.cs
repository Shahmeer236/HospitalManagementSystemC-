using HospitalManagementSystem.Dtos.Appointment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAppointmentRepository
{
    Task<List<AppointmentDto>> GetAppointmentsAsync(string? search);
    Task<Guid> AddAppointmentAsync(Appointment appointment);
    Task<AppointmentDto> GetAppointmentByIdAsync(Guid id);
    Task<bool> UpdateAppointmentAsync(AppointmentForUpdation appointmentForUpdation);
    Task<bool> DeleteAppointmentAsync(Guid id);

    // Add these methods to check for the existence of doctors and patients
    Task<bool> DoesDoctorExistAsync(Guid doctorId);
    Task<bool> DoesPatientExistAsync(Guid patientId);
}
