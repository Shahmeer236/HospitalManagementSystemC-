using HospitalManagementSystem.Dtos.User;

namespace HospitalManagementSystem.Services.Interface
{
    public interface IUserServices
    {
        Task <Guid> AddUserAsync (UserForCreation userForCreation );
        Task<List<User>> GetUsersAsync(string search);

        Task<User> GetUserByEmailAsync (string email);
       Task<List<User>> GetUsersByRoleAsync(String role);

        Task<UserDto> GetUserByIdAsync (Guid id);

        Task<bool> UpdateUserAsync(UserForUpdation userForUpdation);
        Task<bool> DeleteUserById(Guid id);

        Task<bool> EmailValidator(String email);
    }
}
