using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MedicalRecord
{
    [Key]
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }  

    [ForeignKey("PatientId")]
    public Patient Patient { get; set; }

    [ForeignKey("DoctorId")]
    public Doctor Doctor { get; set; }

    [Required]
    public DateTime RecordDate { get; set; }

    [Required]
    public string Diagnosis { get; set; }

    [Required]
    public string Treatment { get; set; }
}
