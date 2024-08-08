
using HospitalManagementSystem.Dtos.User;




namespace HospitalManagementSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
       Task<List<User>> GetUsersAsync(string? search);
        Task<Guid> AddUserAsync(UserForCreation userForCreation);
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<bool> UpdateUserAsync(UserForUpdation userForUpdation);
        Task<bool> DeleteUsersAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);

        Task<List<User>> GetUsersByRoleAsync(string role);
        
        Task<bool> EmailValidator(string email);
        

    }
}
