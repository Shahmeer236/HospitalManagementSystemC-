using HospitalManagementSystem.Dtos.Appointment;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<AppointmentDto>> GetAppointmentsAsync(string? search) =>
        await _appointmentRepository.GetAppointmentsAsync(search);

    public async Task<Guid> CreateAppointmentAsync(AppointmentForCreation appointmentForCreation)
    {
        if (!await _appointmentRepository.DoesDoctorExistAsync(appointmentForCreation.DoctorId))
        {
            throw new ArgumentException("Doctor does not exist");
        }

        if (!await _appointmentRepository.DoesPatientExistAsync(appointmentForCreation.PatientId))
        {
            throw new ArgumentException("Patient does not exist");
        }

        var appointment = new Appointment
        {
            PatientId = appointmentForCreation.PatientId,
            DoctorId = appointmentForCreation.DoctorId,
            AppointmentDate = appointmentForCreation.AppointmentDate,
            AppointmentTime = TimeSpan.Parse(appointmentForCreation.AppointmentTime),
            ReasonForVisit = appointmentForCreation.ReasonForVisit
        };

        return await _appointmentRepository.AddAppointmentAsync(appointment);
    }

    public async Task<AppointmentDto> GetAppointmentByIdAsync(Guid id) =>
        await _appointmentRepository.GetAppointmentByIdAsync(id);

    public async Task<bool> UpdateAppointmentAsync(AppointmentForUpdation appointmentForUpdation) =>
        await _appointmentRepository.UpdateAppointmentAsync(appointmentForUpdation);

    public async Task<bool> DeleteAppointmentAsync(Guid id) =>
        await _appointmentRepository.DeleteAppointmentAsync(id);
}
