using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Dtos.Room
{
    public class RoomForListing
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public string RoomType { get; set; }
        public Guid DepartmentId { get; set; }

        [Required]
        public string Status { get; set; }
        [Required]
        public string charges { get; set; }


    }
}
