using JobsPortal.API.Data;
using JobsPortal.API.Models;
using JobsPortal.API.Repositories.IRepository;

namespace JobsPortal.API.Repositories
{
    public class JobDetailsRepository :Repository<JobDetails>, IJobDetailsRepository
    {
        private readonly ApplicationDbContext _db;
        public JobDetailsRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(JobDetails jobDetails)
        {
            _db.Update(jobDetails);
            _db.SaveChanges();
        }
        
        public void AddJobDetails(JobDetails jobDetails, int employeeId)
        {
            var employee =_db.EmployerCompanies.Where(x=>x.Id == jobDetails.EmployerCompany.Id).FirstOrDefault();
            _db.ChangeTracker.Clear();
            if (employee != null) {
                _db.Add(jobDetails);
                _db.SaveChanges();
            }
               
            throw new Exception();
        }
        //public JobDetails GetFirstOrDefault(int id)
        //{
        //    var result = _db.JobDetails.Where(jobdetail => jobdetail.Id == id).FirstOrDefault();
        //    return result;
        //}

        public JobDetails GetFirstOrDefault(int jobDetailsId, int adminId)
        {
            var admin = _db.Admins.Where(x => x.Id == adminId).FirstOrDefault();
            var result = admin?.JobDetails?.Where(x => x.Id == jobDetailsId).FirstOrDefault();
            return result;
        }
    }
}
