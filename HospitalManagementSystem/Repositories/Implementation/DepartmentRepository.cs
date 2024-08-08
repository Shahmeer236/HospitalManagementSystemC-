using HospitalManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repositories.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HospitalManagementSystemDbContext _context;

        public DepartmentRepository(HospitalManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync(string? search)
        {
            IQueryable<Department> query = _context.Departments.Include(d => d.Doctors).Include(d => d.Rooms);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(d => d.DepartmentName.Contains(search) || d.Location.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<Guid> AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department.Id;
        }

        public async Task<Department> GetDepartmentByIdAsync(Guid id)
        {
            return await _context.Departments.Include(d => d.Doctors).Include(d => d.Rooms).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDepartmentAsync(Guid id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
