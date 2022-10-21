using JobsPortal.API.Data;
using JobsPortal.API.Models;
using JobsPortal.API.Repositories.IRepository;

namespace JobsPortal.API.Repositories
{
    public class EmployerCompanyRepository : Repository<EmployerCompany>, IEmployerCompanyRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployerCompanyRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(EmployerCompany employer)
        {
            _db.Update(employer);
            _db.SaveChanges();
        }

        //public EmployerCompany GetFirstOrDefault(EmployerCompany employer)
        //{
        //    var result = _db.EmployerCompanies.Where(company => company.Id == employer.Id)
        //        .FirstOrDefault();
        //    return result;
        //}

        public void AddEmployerCompany(EmployerCompany employerCompany)
        {
            _db.Add(employerCompany);
            _db.SaveChanges();
        }

        public EmployerCompany GetFirstOrDefault(int id)
        {
            var result = _db.EmployerCompanies.Where(company => company.Id == id).FirstOrDefault();
            return result;
        }
    }
}
