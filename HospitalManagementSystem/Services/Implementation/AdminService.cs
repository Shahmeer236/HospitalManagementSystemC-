using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HospitalManagementSystem.Dtos.Admin;
using HospitalManagementSystem.Model;
using HospitalManagementSystem.Repositories.Interfaces;
using HospitalManagementSystem.Services.Interfaces;

namespace HospitalManagementSystem.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<AdminDto>> GetAdminsAsync(string? search)
        {
            var admins = await _adminRepository.GetAdminsAsync(search);
            return _mapper.Map<List<AdminDto>>(admins);
        }

        public async Task<Guid> CreateAdminAsync(AdminForCreation adminForCreation)
        {
            // Validate the email
            var user = await _userRepository.GetUserByEmailAsync(adminForCreation.Email);
            if (user == null)
            {
                throw new ArgumentException("Email does not exist.");
            }

            // Check if the user role is admin
            if (user.Role != "Admin")
            {
                throw new ArgumentException("User does not have the admin role.");
            }

            // Create the Admin
            var admin = _mapper.Map<Admin>(adminForCreation);
            admin.UserId = user.Id; // Set the UserId for the Admin
            return await _adminRepository.AddAdminAsync(admin);
        }

        public async Task<AdminDto> GetAdminByIdAsync(Guid id)
        {
            var admin = await _adminRepository.GetAdminByIdAsync(id);
            return _mapper.Map<AdminDto>(admin);
        }

        public async Task<bool> UpdateAdminAsync(AdminForUpdation adminForUpdation)
        {
            var admin = _mapper.Map<Admin>(adminForUpdation);
            await _adminRepository.UpdateAdminAsync(admin);
            return true;
        }

        public async Task<bool> DeleteAdminAsync(Guid id)
        {
            return await _adminRepository.DeleteAdminAsync(id);
        }
    }
}
