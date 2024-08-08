
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Room
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string RoomNumber { get; set; }

    [Required]
    public string RoomType { get; set; }
    public Guid? DepartmentId { get; set; } 

    [Required]
    public decimal  Charges { get; set; }

    [Required]
    [RegularExpression("^(Available|Occupied)$", ErrorMessage = "Status must be either 'Available' or 'Occupied'.")]
    public string Status { get; set; }

    [ForeignKey("DepartmentId")]
    public Department? Department { get; set; }

    public ICollection<Admission> Admissions { get; set; }
}
