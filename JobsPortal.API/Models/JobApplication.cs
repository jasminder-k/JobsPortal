using System.ComponentModel.DataAnnotations;

namespace JobsPortal.API.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }
        public int? JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public DateTime AppliedOn { get; set; }
    }
}
