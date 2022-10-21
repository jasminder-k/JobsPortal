namespace JobsPortal.API.Models
{
    public class JobDetails
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public int? EmployerCompanyId { get; set; }
        public EmployerCompany EmployerCompany { get; set; }
        public int? AdminId { get; set; }
        public Admin Admin { get; set; }

    }
}
