using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Entities;
using System.Text;

public class LabTestReportRepository : ILabTestReportRepository
{
    private readonly HospitalManagementSystemDbContext _context;

    public LabTestReportRepository(HospitalManagementSystemDbContext context)
    {
        _context = context;
    }

    public async Task<List<LabTestReport>> GetAllLabTestReportsAsync()
    {
        return await _context.LabTestReports
                             .Include(l => l.Patient)
                             .Include(l => l.PrescribedTest)
                             .ToListAsync();
    }

    public async Task<LabTestReport> GetLabTestReportByIdAsync(Guid id)
    {
        return await _context.LabTestReports
                             .Include(l => l.Patient)
                             .Include(l => l.PrescribedTest)
                             .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Guid> AddLabTestReportAsync(LabTestReport labTestReport)
    {
        _context.LabTestReports.Add(labTestReport);
        await _context.SaveChangesAsync();
        return labTestReport.Id;
    }

    public async Task<bool> UpdateLabTestReportAsync(LabTestReport labTestReport)
    {
        _context.LabTestReports.Update(labTestReport);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }

    public async Task<bool> DeleteLabTestReportAsync(Guid id)
    {
        var report = await _context.LabTestReports.FindAsync(id);
        if (report == null)
        {
            return false;
        }
        _context.LabTestReports.Remove(report);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }


    //public async Task<LabTestReport> DownloadLabTestReportById(Guid id)
    //{
    //    string path = "C:\\Users\\ROYAL COMPUTER\\Downloads";
    //    var downloadableReport= await _context.LabTestReports
    //                         .Include(l => l.Patient)
    //                         .Include(l => l.PrescribedTest)
    //                         .FirstOrDefaultAsync(l => l.Id == id);
    //        File.CreateText(path).Write(downloadableReport);

    //    return downloadableReport;
    //}


    public async Task<LabTestReport> DownloadLabTestReportById(Guid id)
    {
        // Get the path to the user's Downloads folder
        string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

        // Specify the file name
        string filePath = Path.Combine(downloadsPath, "LabTestReport.txt");

        // Fetch the report from the database
        var report = await _context.LabTestReports
                                   .Include(l => l.Patient)
                                   .Include(l => l.PrescribedTest)
                                   .FirstOrDefaultAsync(l => l.Id == id);

        if (report == null)
        {
            throw new FileNotFoundException("Lab test report not found.");
        }

        // Prepare the content for the file
        StringBuilder reportContent = new StringBuilder();
        reportContent.AppendLine("Lab Test Report");
        reportContent.AppendLine("--------------------------");
        reportContent.AppendLine($"Report ID: {report.Id}");
        reportContent.AppendLine($"Patient Name: {report.Patient.FirstName}");
        reportContent.AppendLine($"Test Name: {report.PrescribedTest.TestName}");
        //reportContent.AppendLine($"Date Conducted: {report..ToString("yyyy-MM-dd")}");
        reportContent.AppendLine($"Result: {report.ReportDetails}");
        reportContent.AppendLine("--------------------------");
        reportContent.AppendLine("End of Report");

        // Write the content to the file
        try
        {
            await File.WriteAllTextAsync(filePath, reportContent.ToString());
        }
        catch (UnauthorizedAccessException ex)
        {
            // Handle exceptions (e.g., log the error, return an error message)
            Console.WriteLine("Access to the file path was denied: " + ex.Message);
        }

        return report;
    }
}
