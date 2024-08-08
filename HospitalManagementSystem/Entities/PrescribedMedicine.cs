using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Entities
{
    public class PrescribedMedicine
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string MedicineName { get; set; }

        public string Dosage { get; set; }

        public string Instructions { get; set; }
    }
}
