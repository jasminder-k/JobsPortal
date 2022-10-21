namespace JobsPortal.API.Models
{
    public class JobDetailsDTO
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public int? EmployerCompanyId { get; set; }
        public EmployerCompanyDTO EmployerCompany { get; set; }
        public int? AdminId { get; set; }
        public AdminDTO Admin { get; set; }

    }
}
