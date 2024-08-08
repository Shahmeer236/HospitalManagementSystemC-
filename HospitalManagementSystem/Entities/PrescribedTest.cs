using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Entities
{
    public class PrescribedTest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string TestName { get; set; }

        public string Instructions { get; set; }
    }
}
