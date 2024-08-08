using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dtos.Doctor
{
    public class DoctorDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Specialty { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
