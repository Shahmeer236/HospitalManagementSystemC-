using HospitalManagementSystem.Dtos.User;
using HospitalManagementSystem.Repositories.Interfaces;
using HospitalManagementSystem.Services.Interface;


namespace HospitalManagementSystem.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> AddUserAsync(UserForCreation userForCreation)
        {
            return await _userRepository.AddUserAsync(userForCreation);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email); 
        }

        public async Task<List<User>> GetUsersAsync(string? search)
        {
            
              
            return await _userRepository.GetUsersAsync(search);
        }


         async Task<List<User>> IUserServices.GetUsersByRoleAsync(string role)
        {
            return await _userRepository.GetUsersByRoleAsync(role);
        }

        async Task<UserDto> IUserServices.GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<bool> UpdateUserAsync(UserForUpdation userForUpdation)
        {
            return await _userRepository.UpdateUserAsync(userForUpdation);
        }

        public async Task<bool> DeleteUserById(Guid id)
        {
            return await _userRepository.DeleteUsersAsync(id);
        }

        public async Task<bool> EmailValidator(string email)
        {
            return await _userRepository.EmailValidator(email);
        }
    }
}