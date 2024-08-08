using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dtos.User
{
    public class UserForUpdation
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(Patient|Doctor)$", ErrorMessage = "Role must be either 'Patient' or 'Doctor'.")]
        public string Role { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
