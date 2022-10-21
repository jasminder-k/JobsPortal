namespace JobsPortal.API.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public User AdminUser { get; set; }
        public List<JobDetails>? JobDetails { get; set; }
        public List<Resume>? Resumes { get; set; }
        public List<Job>? Jobs { get; set; }
    }
}
