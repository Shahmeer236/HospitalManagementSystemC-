
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression("^(Patient|Doctor|Admin)$", ErrorMessage = "Role must be either 'Patient' or 'Doctor'.")]
    public string Role { get; set; }

    [Required]
    [RegularExpression("^(Yes|No)$", ErrorMessage = "Status must be either 'Yes' or 'No'.")]

    public bool IsActive { get; set; }

    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}
