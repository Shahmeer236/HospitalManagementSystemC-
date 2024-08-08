using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dtos.Appointment
{
    public class AppointmentForCreation
    {
      
        public Guid PatientId { get; set; }


        public Guid DoctorId { get; set; }



        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string AppointmentTime { get; set; }

        [Required]
        public string ReasonForVisit { get; set; }
    }
}
