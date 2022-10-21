using JobsPortal.API.Data;
using JobsPortal.API.Models;
using JobsPortal.API.Repositories.IRepository;

namespace JobsPortal.API.Repositories
{
    public class JobSeekerRepository :Repository<JobSeeker>, IJobSeekerRepository
    {
        private readonly ApplicationDbContext _db;
        public JobSeekerRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(JobSeeker jobSeeker)
        {
            _db.Update(jobSeeker);
            _db.SaveChanges();
        }
        public void AddJobSeeker(JobSeeker jobSeeker)
        {
            _db.Add(jobSeeker);
            _db.SaveChanges();
        }

        public JobSeeker GetFirstOrDefault(int id)
        {
            var result = _db.JobSeekers.Where(profile => profile.Id == id).FirstOrDefault();
            return result;
        }
    }
}
