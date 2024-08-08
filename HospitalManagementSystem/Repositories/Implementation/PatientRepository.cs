using AutoMapper;
using HospitalManagementSystem.Dtos.Patient;
using HospitalManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repositories.Implementation
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalManagementSystemDbContext _context;
        private readonly IMapper _mapper;

        public PatientRepository(HospitalManagementSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> GetPatientAsync(string? search)
        {
            IQueryable<Patient> query = _context.Patients;

            if (!string.IsNullOrEmpty(search))
            {
                Guid id;
                if (Guid.TryParse(search, out id))
                {
                    query = query.Where(p => p.Id == id);
                }
                else if (search.Contains("@"))
                {
                    query = query.Where(p => p.Email.Contains(search));
                }
                else
                {
                    query = query.Where(p => p.FirstName.Contains(search) ||
                                              p.LastName.Contains(search) ||
                                              p.Email.Contains(search));
                }
            }

            var patients = await query.ToListAsync();
            return _mapper.Map<List<PatientDto>>(patients);
        }

        public async Task<Guid> AddPatientAsync(PatientForCreation patientForCreation)
        {
            var patient = _mapper.Map<Patient>(patientForCreation);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient.Id;
        }

        public async Task<PatientDto> GetPatientByIdAsync(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<bool> UpdatePatientAsync(PatientForUpdation patientForUpdation)
        {
            var patient = await _context.Patients.FindAsync(patientForUpdation.Id);
            if (patient == null)
            {
                return false;
            }

            _mapper.Map(patientForUpdation, patient);
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePatientAsync(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return false;
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PatientDto> GetPatientByEmailAsync(string email)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Email == email);
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto> GetPatientByNameAsync(string firstName)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.FirstName == firstName);
            return _mapper.Map<PatientDto>(patient);
        }

        // Optional methods if needed
        public Task<bool> UserIdValidator(Guid id) => throw new NotImplementedException();
        public Task<bool> UserRoleValidator(string role) => throw new NotImplementedException();
    }
}
