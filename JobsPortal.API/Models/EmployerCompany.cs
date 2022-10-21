﻿using System.ComponentModel.DataAnnotations;

namespace JobsPortal.API.Models
{
    public class EmployerCompany
    {
        public int Id { get; set; }
        public User EmployerCompanyUser { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "maximum {1} characters allowed")]
        public string CompanyName { get; set; }
        public string? CompanyPhone { get; set; }
        public List<JobDetails>? JobDetails { get; set; }
    }
}