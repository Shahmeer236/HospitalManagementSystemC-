using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalManagementSystem.Entities;

public class Prescription
{
    [Key]
    public Guid Id { get; set; }

    public Guid DoctorId { get; set; }

    [ForeignKey(nameof(DoctorId))]
    public Doctor Doctor { get; set; }

    public Guid PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; }

    public Guid? PrescribedMedicineId { get; set; }

    [ForeignKey(nameof(PrescribedMedicineId))]
    public PrescribedMedicine PrescribedMedicine { get; set; }

    public Guid? PrescribedTestId { get; set; }

    [ForeignKey(nameof(PrescribedTestId))]
    public PrescribedTest PrescribedTest { get; set; }

    [Required]
    public DateTime DatePrescribed { get; set; }
}
