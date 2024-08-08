using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dtos.User
{
    public class UserForCreation
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

     
        

        [Required]
        [RegularExpression("^(Patient|Doctor|Admin)$", ErrorMessage = "Role must be either 'Patient' or 'Doctor'.")]
        public string Role { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
