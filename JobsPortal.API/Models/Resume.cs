namespace JobsPortal.API.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public int? AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}
