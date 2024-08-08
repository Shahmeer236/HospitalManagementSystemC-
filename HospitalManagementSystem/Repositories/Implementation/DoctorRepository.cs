using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using HospitalManagementSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HospitalManagementSystem.Repositories.Implementation
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalManagementSystemDbContext _context;

        public DoctorRepository(HospitalManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync(string? search)
        {
            IQueryable<Doctor> query = _context.Doctors;

            if (!string.IsNullOrEmpty(search))
            {
                Guid id;
                if (Guid.TryParse(search, out id))
                {
                    query = query.Where(d => d.Id == id);
                }
                else if (search.Contains("@"))
                {
                    query = query.Where(d => d.Email.Contains(search));
                }
                else
                {
                    query = query.Where(d => d.FirstName.Contains(search) ||
                                              d.Specialty.Contains(search) ||
                                              d.PhoneNumber.Contains(search));
                }
            }

            return await query.ToListAsync();
        }

        public async Task<Guid> AddDoctorAsync(Doctor doctor)
        {
           // Check if the department exists
            var departmentExists = await _context.Departments.AnyAsync(d => d.Id == doctor.DepartmentId);
            if (!departmentExists)
            {
                throw new ArgumentException("Invalid DepartmentId");
            }

            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        //    ////return doctor.Id;
            return  doctor.Id;
        }

        public async Task<Doctor> GetDoctorByIdAsync(Guid id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            // check if the department exists before updating
            var departmentexists = await _context.Departments.AnyAsync(d => d.Id == doctor.DepartmentId);
            if (!departmentexists)
            {
                throw new ArgumentException("invalid departmentid");
            }

            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDoctorAsync(Guid id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return false;
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
