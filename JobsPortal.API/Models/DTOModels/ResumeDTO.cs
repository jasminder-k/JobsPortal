namespace JobsPortal.API.Models.DTOModels
{
    public class ResumeDTO
    {
        public int Id { get; set; }
        public JobSeekerDTO JobSeeker { get; set; }
        public int? AdminId { get; set; }
        public AdminDTO Admin { get; set; }
        public string Details { get; set; }
    }
}
