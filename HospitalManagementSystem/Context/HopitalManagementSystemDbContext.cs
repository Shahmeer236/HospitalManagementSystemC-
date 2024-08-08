using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

public class HospitalManagementSystemDbContext : DbContext
{
    public HospitalManagementSystemDbContext(DbContextOptions<HospitalManagementSystemDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Admission> Admissions { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
    public DbSet<PrescribedTest> PrescribedTests { get; set; }
    public DbSet<LabTestReport> LabTestReports { get; set; }// Added DbSet for LabTestReport
     
    public DbSet<Bill> Bill { get; set;}
    public DbSet<Admin> Admins{ get; set; }




}
