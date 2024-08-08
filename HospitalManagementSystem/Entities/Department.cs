
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Department
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string DepartmentName { get; set; }

    [Required]
    public string Location { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
    public ICollection<Room> Rooms { get; set; }
}
