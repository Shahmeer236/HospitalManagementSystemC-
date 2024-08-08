public class LabTestReportForCreation
{
    public Guid PatientId { get; set; }
    public Guid PrescribedTestId { get; set; }
    public DateTime DateOfReport { get; set; }
    public decimal Charges { get; set; }
    public string ReportDetails { get; set; }
}
