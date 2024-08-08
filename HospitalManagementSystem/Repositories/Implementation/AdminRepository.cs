using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Model;
using HospitalManagementSystem.Repositories.Interfaces;

namespace HospitalManagementSystem.Repositories.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private readonly HospitalManagementSystemDbContext _context;

        public AdminRepository(HospitalManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admin>> GetAdminsAsync(string? search)
        {
            IQueryable<Admin> query = _context.Admins;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.FirstName.Contains(search) ||
                                          a.LastName.Contains(search) ||
                                          a.Email.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<Guid> AddAdminAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return admin.Id;
        }

        public async Task<Admin> GetAdminByIdAsync(Guid id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task UpdateAdminAsync(Admin admin)
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAdminAsync(Guid id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return false;
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
