using JobsPortal.API.Data;
using JobsPortal.API.Models;
using JobsPortal.API.Repositories.IRepository;

namespace JobsPortal.API.Repositories
{
    public class JobApplicationRepository :Repository<JobApplication>, IJobApplicatonRepository
    {
        private readonly ApplicationDbContext _db;
        public JobApplicationRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(JobApplication app)
        {
            _db.Update(app);
            _db.SaveChanges();
        }
        
        public void AddJobApp(JobApplication app)
        {
            _db.Add(app);
            _db.SaveChanges();
        }
        public JobApplication GetFirstDefault(int id)
        {
            var result = _db.JobApplications.Where(app => app.Id == id).FirstOrDefault();
            return result;
        }
        public List<JobApplication> GetAllJobApplicationByJobId(int jobId)
        {
            var result = _db.JobApplications.Where(x=>x.JobId==jobId).ToList();
            return result;
        }
        public List<JobApplication> GetAllJobApplicationsByJobSeekerById(int jobseekerId)
        {
            var result = _db.JobApplications.Where(x=>x.JobSeekerId==jobseekerId).ToList();
            return result;
        }
    }
}
