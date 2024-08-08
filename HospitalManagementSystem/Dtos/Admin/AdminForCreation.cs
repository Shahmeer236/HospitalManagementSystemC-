﻿using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Dtos.Admin
{
    public class AdminForCreation
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
