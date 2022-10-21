using JobsPortal.API.Models.DTOModels;
using System.ComponentModel.DataAnnotations;

namespace JobsPortal.API.Models
{
    public class JobApplicationDTO
    {
        [Key]
        public int Id { get; set; }
        public int? JobSeekerId { get; set; }
        public JobSeekerDTO JobSeeker { get; set; }
        public int JobId { get; set; }
        public JobDTO Job { get; set; }
        public DateTime AppliedOn { get; set; }
    }
}
