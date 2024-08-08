using System;

public class PrescriptionForUpdation
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public Guid? PrescribedMedicineId { get; set; }
    public Guid? PrescribedTestId { get; set; }
    public DateTime DatePrescribed { get; set; }
}
