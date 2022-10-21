using JobsPortal.API.Models.DTOModels;

namespace JobsPortal.API.Models
{
    public class AdminDTO
    {
        public int Id { get; set; }
        public UserDTO AdminUser { get; set; }
        public List<JobDetailsDTO>? JobDetails { get; set; }
        public List<ResumeDTO>? Resumes { get; set; }
        public List<JobDTO>? Jobs { get; set; }
    }
}
