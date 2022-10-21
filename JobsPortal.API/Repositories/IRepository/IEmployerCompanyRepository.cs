using JobsPortal.API.Models;

namespace JobsPortal.API.Repositories.IRepository
{
    public interface IEmployerCompanyRepository
    {
        void Update(EmployerCompany employer);
        EmployerCompany GetFirstOrDefault(int id);
        void AddEmployerCompany(EmployerCompany employerCompany);
    }
}
