public class BillDto
{
    public Guid Id { get; set; }
    public Guid? AdmissionId { get; set; }
    public Guid? LabTestReportId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime DateOfIssue { get; set; }
}
