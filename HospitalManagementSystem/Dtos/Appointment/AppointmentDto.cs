using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dtos.Appointment
{
    public class AppointmentDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }

      
        public Guid DoctorId { get; set; }

      

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public TimeSpan AppointmentTime { get; set; }

        [Required]
        public string ReasonForVisit { get; set; }
    }
}
