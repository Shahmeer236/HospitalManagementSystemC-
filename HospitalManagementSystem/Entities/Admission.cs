using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Admission
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public Guid RoomId { get; set; }
    [Required]
    public Guid PatientId { get; set; }

    [Required]
    public Guid DoctorId { get; set; }

    [Required]
    public DateTime AdmissionDate { get; set; }

    [Required]
    public string AdmissionReason { get; set; }

    [ForeignKey("PatientId")]
    public Patient Patient { get; set; }

    [ForeignKey("RoomId")]
    public Room? Room { get; set; }

    [ForeignKey("DoctorId")]
    public Doctor Doctor { get; set; }



    public ICollection<Bill> Bills { get; set; } = new List<Bill>();




}
