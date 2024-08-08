using HospitalManagementSystem.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LabTestReport
{
    [Key]
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; }

    public Guid PrescribedTestId { get; set; }

    [ForeignKey(nameof(PrescribedTestId))]
    public PrescribedTest PrescribedTest { get; set; }

    [Required]
    public DateTime DateOfReport { get; set; }

    [Required]
    public decimal Charges { get; set; } // Fee for the lab test

    public string ReportDetails { get; set; } // Additional details about the test
}
