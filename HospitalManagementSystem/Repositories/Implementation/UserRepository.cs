using AutoMapper;
using HospitalManagementSystem.Dtos.User;

using HospitalManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly HospitalManagementSystemDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(HospitalManagementSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

         async Task<Guid> IUserRepository.AddUserAsync(UserForCreation userForCreation)
        {

            var user = _mapper.Map<User>(userForCreation);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

       async Task<bool> IUserRepository.DeleteUsersAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            _context.Users.Remove(user);
            var res = await _context.SaveChangesAsync();

            return res > 0;

        }

      public async  Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Email == email);
            return user;

        }

        async Task<UserDto> IUserRepository.GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x =>x.Id == id);
            return _mapper.Map<UserDto>(user);
        }
        /*
                public async Task<List<User>>  GetUsersAsync(string search)
                {

                    var query = _context.Users
                        .Include(x=>x.Id)
                        .Include(x=>x.Role)
                        .Include(x=>x.Email).AsQueryable();
                    if(string.IsNullOrWhiteSpace(search.))
                    var users = await _context.AsQueryable();
                    if (search!= null)
                    {
                        var user = await _context.Users.ToListAsync();
                        return user;

                    }

                    return user;

                }
                */

        public async Task<List<User>> GetUsersAsync(string? search  )
        {
            try
            {
                // Start with the base query
                var query = _context.Users.AsQueryable();

                if (string.IsNullOrWhiteSpace(search))
                {
                    // If no search criteria, return all users
                    var user = await _context.Users.ToListAsync();
                    return user;
                  //  return await query.ToListAsync();
                }

             /*   if (string.no)
                {
                    var user = await _context.Users.ToListAsync();
                    return user;

                }
             */

                // Check if search string is a GUID (for ID search)
                if (Guid.TryParse(search, out var userId))
                {
                    // Search by ID
                    query = query.Where(user => user.Id == userId);
                }
                else if (search.Contains("@")) // Simple check for email format
                {
                    // Search by email
                    query = query.Where(user => user.Email.ToLower().Contains(search.ToLower()));
                }
                else if (search.Equals("Patient", StringComparison.OrdinalIgnoreCase) ||
                         search.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
                {
                    // Search by role
                    query = query.Where(user => user.Role.ToLower().Equals(search.ToLower()));
                }
                else
                {
                    // Optionally, handle invalid search strings
                    return new List<User>();
                }

                // Execute the query asynchronously and return the result
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                // For example: _logger.LogError(ex, "Error occurred while fetching users");
                throw; // Rethrow or handle exception as needed
            }
        }


        public async Task<bool> UpdateUserAsync(UserForUpdation userForUpdation)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userForUpdation.Id);

            _mapper.Map(userForUpdation, user);

            var res = await _context.SaveChangesAsync();

            return res > 0;


        }

        public async Task<List<User>> GetUsersByRoleAsync(string role)
        {
            return await _context.Users
                                 .Where(x => x.Role == role)
                                 .ToListAsync();
        }
     

        public async Task<bool>EmailValidator(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }
    }
}
