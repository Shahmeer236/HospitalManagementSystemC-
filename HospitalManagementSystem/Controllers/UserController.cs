using AutoMapper;
using HospitalManagementSystem.Dtos.User;
using HospitalManagementSystem.Services.Implementation;
using HospitalManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;
namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserServices _userServices;

        public UserController(IMapper mapper, IUserServices userServices)
        {
            _mapper = mapper;
            _userServices = userServices;
        }

        [HttpPost]
        public async Task<ActionResult<UserForCreation>> AddUserById(UserForCreation userForCreation)
        {
            var validator =await _userServices.EmailValidator(userForCreation.Email);
            if (validator)
            {
                return NotFound(new { Message = "Email already Exist" });
            }
            else
            {
                var userId = await _userServices.AddUserAsync(userForCreation);
                return Ok(userId);
            }

            //var userId = await _userServices.AddUserAsync(userForCreation);

            //return CreatedAtAction(nameof(AddUserById), new { id = userId }, userId);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserForListing>>> GetUsers([FromQuery] string? search)
        {
            var users = await _userServices.GetUsersAsync(search);
            if (users == null || users.Count == 0)
            {
                return NotFound(); // Return 404 Not Found if no users are found
            }

            var userDtos = _mapper.Map<List<UserForListing>>(users);
            return Ok(userDtos);
        }


        /*  [HttpGet]
          public async Task<ActionResult<UserForListing>> GetUsers()
          {
              var users = await _userServices.GetUsersAsync();
              var userDtos = _mapper.Map<List<UserForListing>>(users);
              return Ok(userDtos);
          }
          */

      /*  [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _userServices.GetUserByEmailAsync(email);
            return Ok(user);

        }

        [HttpGet("role/{role}")]
        public async Task<ActionResult<UserForListing>> GetUserByRoleAsync(string role)
        {
            // Call the service method to get users by role
            var users = await _userServices.GetUsersByRoleAsync(role);

            if (users == null || users.Count == 0)
            {
                return NotFound(); // Return 404 if no users found
            }

            var userDtos = _mapper.Map<List<UserForListing>>(users);

            return Ok(userDtos);
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync(Guid id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            return Ok(user);
        }


        */
        [HttpPut]
        public async Task<ActionResult> updateUserById(UserForUpdation userForUpdation)
        {
            var validator = await _userServices.EmailValidator(userForUpdation.Email);
            if (validator)
            {
                return NotFound(new { Message = "Email already Exist" });
            }
            else
            {
                var user = await _userServices.UpdateUserAsync(userForUpdation);
                return Ok(user);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById(Guid id)
        {
            var result = await _userServices.DeleteUserById(id);
            if (!result)
            {
                return NotFound(id);
            }

            return NoContent();
        }




    }

}