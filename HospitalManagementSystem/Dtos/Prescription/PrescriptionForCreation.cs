﻿using System;

public class PrescriptionForCreation
{
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public Guid? PrescribedMedicineId { get; set; }
    public Guid? PrescribedTestId { get; set; }
    public DateTime DatePrescribed { get; set; }
}
