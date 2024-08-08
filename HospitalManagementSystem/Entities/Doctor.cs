
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Doctor
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

    [ForeignKey("UserId")]
    public User? User { get; set; }

    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<MedicalRecord> MedicalRecords { get; set; }
    public ICollection<Admission> Admissions { get; set; }
}
