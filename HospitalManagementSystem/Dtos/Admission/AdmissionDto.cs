using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dtos.Admission
{
    public class AdmissionDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid RoomId { get; set; }
        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        [Required]
        public string AdmissionReason { get; set; }


    }
}
