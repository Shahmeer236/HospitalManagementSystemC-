using HospitalManagementSystem.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Bill
{
    [Key]
    public Guid Id { get; set; }

    //[Required]
    //public Guid PatientId { get; set; }

    public Guid? AdmissionId { get; set; } // Optional, only applicable if the patient is admitted

    [ForeignKey(nameof(AdmissionId))]
    public Admission Admission { get; set; }

    public Guid? LabTestReportId { get; set; } // Optional, applicable if lab tests are done

    [ForeignKey(nameof(LabTestReportId))]
    public LabTestReport LabTestReport { get; set; }

    //public Guid? PrescribedMedicineId { get; set; } // Optional, applicable if medicines are prescribed

    //[ForeignKey(nameof(PrescribedMedicineId))]
    //public PrescribedMedicine PrescribedMedicine { get; set; }

    //public Guid? DoctorId { get; set; } // Optional, applicable if the bill includes doctor’s fees

    //[ForeignKey(nameof(DoctorId))]
    //public Doctor Doctor { get; set; }

    [Required]
    public decimal TotalAmount { get; set; } // Total amount for all charges

    [Required]
    public DateTime DateOfIssue { get; set; }
}
