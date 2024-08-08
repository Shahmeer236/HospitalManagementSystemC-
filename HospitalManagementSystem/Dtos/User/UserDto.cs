using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dtos.User
{
    public class UserDto
    {
        [Key]
        public Guid Id { get; set; }

       

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
    
        public string Role { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
