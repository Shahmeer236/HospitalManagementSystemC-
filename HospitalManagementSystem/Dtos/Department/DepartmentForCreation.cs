using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dtos.Department
{
    public class DepartmentForCreation
    {
       

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
