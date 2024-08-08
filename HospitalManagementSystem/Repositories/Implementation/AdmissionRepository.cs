using AutoMapper;
using HospitalManagementSystem.Dtos.Admission;
using HospitalManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AdmissionRepository : IAdmissionRepository
{
    private readonly HospitalManagementSystemDbContext _context;
    private readonly IMapper _mapper; // Add IMapper

    public AdmissionRepository(HospitalManagementSystemDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper; // Initialize IMapper
    }

    public async Task<List<AdmissionDto>> GetAdmissionsAsync(string? search)
    {
        try
        {
            // Log the search parameter
            Console.WriteLine($"Search parameter: {search}");

            var query = _context.Admissions.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchLower = search.ToLower();

                // Handle Guid search
                if (Guid.TryParse(searchLower, out var searchGuid))
                {
                    Console.WriteLine($"Searching for Guid: {searchGuid}");
                    query = query.Where(a => a.DoctorId == searchGuid
                                           || a.RoomId == searchGuid
                                           || a.PatientId == searchGuid);
                }
                // Handle DateTime search
                else if (DateTime.TryParse(searchLower, out var searchDate))
                {
                    Console.WriteLine($"Searching for Date: {searchDate}");
                    query = query.Where(a => a.AdmissionDate.Date == searchDate.Date);
                }
                else
                {
                    Console.WriteLine($"Unrecognized search parameter: {search}");
                    // Optionally, you could return an empty list if the search parameter is not recognized
                    return new List<AdmissionDto>();
                }
            }

            var admissions = await query.ToListAsync();
            // Log the number of results found
            Console.WriteLine($"Number of results found: {admissions.Count}");
            return _mapper.Map<List<AdmissionDto>>(admissions);
        }
        catch (Exception ex)
        {
            // Log the exception details
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");

            // Optionally, you can rethrow the exception or return an empty list
            // throw; // Uncomment to rethrow
            return new List<AdmissionDto>();
        }
    }

    public async Task<Guid> AddAdmissionAsync(AdmissionForCreation admissionForCreation)
    {
        // Check if the room is available
        var room = await _context.Rooms.FindAsync(admissionForCreation.RoomId);
        if (room == null || room.Status != "Available")
        {
            throw new InvalidOperationException("The room is not available for admission.");
        }

        var admission = new Admission
        {
            Id = Guid.NewGuid(),
            RoomId = admissionForCreation.RoomId,
            PatientId = admissionForCreation.PatientId,
            DoctorId = admissionForCreation.DoctorId,
            AdmissionDate = admissionForCreation.AdmissionDate,
            AdmissionReason = admissionForCreation.AdmissionReason
        };

        _context.Admissions.Add(admission);
        await _context.SaveChangesAsync();
        return admission.Id;
    }

    public async Task<AdmissionDto> GetAdmissionByIdAsync(Guid id)
    {
        var admission = await _context.Admissions
            .Where(a => a.Id == id)
            .Select(a => new AdmissionDto
            {
                Id = a.Id,
                RoomId = a.RoomId,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                AdmissionDate = a.AdmissionDate,
                AdmissionReason = a.AdmissionReason
            })
            .FirstOrDefaultAsync();

        return admission;
    }

    public async Task<bool> UpdateAdmissionAsync(AdmissionForUpdation admissionForUpdation)
    {
        var admission = await _context.Admissions.FindAsync(admissionForUpdation.Id);

        if (admission == null)
        {
            return false;
        }

        admission.RoomId = admissionForUpdation.RoomId;
        admission.PatientId = admissionForUpdation.PatientId;
        admission.DoctorId = admissionForUpdation.DoctorId;
        admission.AdmissionDate = admissionForUpdation.AdmissionDate;
        admission.AdmissionReason = admissionForUpdation.AdmissionReason;

        _context.Admissions.Update(admission);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAdmissionAsync(Guid id)
    {
        var admission = await _context.Admissions.FindAsync(id);

        if (admission == null)
        {
            return false;
        }

        _context.Admissions.Remove(admission);
        await _context.SaveChangesAsync();
        return true;
    }
}
