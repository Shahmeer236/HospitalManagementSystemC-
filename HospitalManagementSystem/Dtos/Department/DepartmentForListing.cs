using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dtos.Department
{
    public class DepartmentForListing
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
