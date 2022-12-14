using JobsPortal.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace JobsPortal.API.Models
{
    public class JobDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public JobType JobType { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Skill { get; set; }
        public int Salary { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public int NumberVacancies { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? AdminId { get; set; }
        public AdminDTO Admin { get; set; }
        public List<JobApplication>? JobAppications { get; set; }
    }
}
