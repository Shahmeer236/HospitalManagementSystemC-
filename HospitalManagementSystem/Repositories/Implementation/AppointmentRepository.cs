using AutoMapper;
using HospitalManagementSystem.Dtos.Appointment;
using Microsoft.EntityFrameworkCore;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly HospitalManagementSystemDbContext _context;
    private readonly IMapper _mapper;

    public AppointmentRepository(HospitalManagementSystemDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /*   public async Task<List<AppointmentDto>> GetAppointmentsAsync(string? search)
       {
           IQueryable<Appointment> query = _context.Appointments;

           if (!string.IsNullOrEmpty(search))
           {
               // Try to parse search parameter as a GUID
               if (Guid.TryParse(search, out var searchGuid))
               {
                   query = query.Where(a => a.PatientId == searchGuid || a.DoctorId == searchGuid);
               }
               else if (DateTime.TryParse(search, out var searchDate))
               {
                   // Filter by appointment date
                   query = query.Where(a => a.AppointmentDate.Date == searchDate.Date);
               }
               else if (TimeSpan.TryParse(search, out var searchTime))
               {
                   // Filter by appointment time
                   query = query.Where(a => a.AppointmentTime == searchTime);
               }
               else
               {
                   // Filter by reason for visit if search is a string but not a date or time
                   query = query.Where(a => a.ReasonForVisit.Contains(search));
               }
           }

           var appointments = await query.ToListAsync();
           return _mapper.Map<List<AppointmentDto>>(appointments);
       }

       */


    /*
        public async Task<List<AppointmentDto>> GetAppointmentsAsync(string? search)
        {
            IQueryable<Appointment> query = _context.Appointments;

            if (!string.IsNullOrEmpty(search))
            {
                if (Guid.TryParse(search, out var searchGuid))
                {
                    // Filter by PatientId or DoctorId
                    query = query.Where(a => a.PatientId == searchGuid || a.DoctorId == searchGuid);
                }
                else if (DateTime.TryParse(search, out var searchDate))
                {
                    // Filter by AppointmentDate
                    query = query.Where(a => a.AppointmentDate.Date == searchDate.Date);
                }
                else if (search.Contains(":"))
                {
                    // Handle filtering by exact time format "HH:mm"
                    if (TimeSpan.TryParse(search, out var searchTime))
                    {
                        query = query.Where(a => a.AppointmentTime == searchTime);
                    }
                }
                else if (int.TryParse(search, out var searchHour))
                {
                    // Handle filtering by hour
                    query = query.Where(a => a.AppointmentTime.Hours == searchHour);
                }
                else
                {
                    // Filter by ReasonForVisit
                    query = query.Where(a => a.ReasonForVisit.Contains(search));
                }
            }

            var appointments = await query.ToListAsync();
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        */

    /*
        public async Task<List<AppointmentDto>> GetAppointmentsAsync(string? search)
        {
            IQueryable<Appointment> query = _context.Appointments;

            if (!string.IsNullOrEmpty(search))
            {
                if (Guid.TryParse(search, out var searchGuid))
                {
                    // Filter by PatientId or DoctorId
                    query = query.Where(a => a.PatientId == searchGuid || a.DoctorId == searchGuid);
                }
                else if (DateTime.TryParse(search, out var searchDate))
                {
                    // Filter by AppointmentDate
                    query = query.Where(a => a.AppointmentDate.Date == searchDate.Date);
                }
                else if (search.Contains(":"))
                {
                    // Handle filtering by exact time format "HH:mm:ss"
                    if (TimeSpan.TryParse(search, out var searchTime))
                    {
                        query = query.Where(a => a.AppointmentTime.Hours == searchTime.Hours &&
                                                  a.AppointmentTime.Minutes == searchTime.Minutes &&
                                                  a.AppointmentTime.Seconds == searchTime.Seconds);
                    }
                }
                else if (int.TryParse(search, out var searchHour))
                {
                    // Handle filtering by hour
                    query = query.Where(a => a.AppointmentTime.Hours == searchHour);
                }
                else
                {
                    // Filter by ReasonForVisit
                    query = query.Where(a => a.ReasonForVisit.Contains(search));
                }
            }

            var appointments = await query.ToListAsync();
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        */


    public async Task<List<AppointmentDto>> GetAppointmentsAsync(string? search)
    {
        IQueryable<Appointment> query = _context.Appointments;

        if (!string.IsNullOrEmpty(search))
        {
            if (Guid.TryParse(search, out var searchGuid))
            {
                // Filter by PatientId or DoctorId
                query = query.Where(a => a.PatientId == searchGuid || a.DoctorId == searchGuid);
            }
            else if (DateTime.TryParse(search, out var searchDate))
            {
                // Filter by AppointmentDate
                query = query.Where(a => a.AppointmentDate.Date == searchDate.Date);
            }
            else if (search.Contains(":"))
            {
                // Handle filtering by exact time format "HH:mm:ss" or "HH:mm"
                if (TimeSpan.TryParse(search, out var searchTime))
                {
                    query = query.Where(a => a.AppointmentTime.Hours == searchTime.Hours &&
                                              a.AppointmentTime.Minutes == searchTime.Minutes &&
                                              a.AppointmentTime.Seconds == searchTime.Seconds);
                }
                else
                {
                    // Try to parse as "HH:mm" format if "HH:mm:ss" parsing fails
                    var timeParts = search.Split(':');
                    if (timeParts.Length == 2 && int.TryParse(timeParts[0], out var hours) && int.TryParse(timeParts[1], out var minutes))
                    {
                        query = query.Where(a => a.AppointmentTime.Hours == hours &&
                                                  a.AppointmentTime.Minutes == minutes);
                    }
                }
            }
            else
            {
                // Filter by ReasonForVisit
                query = query.Where(a => a.ReasonForVisit.Contains(search));
            }
        }

        var appointments = await query.ToListAsync();
        return _mapper.Map<List<AppointmentDto>>(appointments);
    }

    public async Task<Guid> AddAppointmentAsync(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        return appointment.Id;
    }

    public async Task<AppointmentDto> GetAppointmentByIdAsync(Guid id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        return _mapper.Map<AppointmentDto>(appointment);
    }

    public async Task<bool> UpdateAppointmentAsync(AppointmentForUpdation appointmentForUpdation)
    {
        var appointment = await _context.Appointments.FindAsync(appointmentForUpdation.Id);
        if (appointment == null)
        {
            return false;
        }

        _mapper.Map(appointmentForUpdation, appointment);
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAppointmentAsync(Guid id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return false;
        }

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DoesDoctorExistAsync(Guid doctorId)
    {
        return await _context.Doctors.AnyAsync(d => d.Id == doctorId);
    }

    public async Task<bool> DoesPatientExistAsync(Guid patientId)
    {
        return await _context.Patients.AnyAsync(p => p.Id == patientId);
    }
}
