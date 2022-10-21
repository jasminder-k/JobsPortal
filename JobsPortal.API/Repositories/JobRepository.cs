using JobsPortal.API.Data;
using JobsPortal.API.Models;
using JobsPortal.API.Repositories.IRepository;

namespace JobsPortal.API.Repositories
{
    public class JobRepository :Repository<Job>, IJobRepository
    {
        private readonly ApplicationDbContext _db;
        public JobRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Job job)
        {
            _db.Update(job);
            _db.SaveChanges();
        }
        
        public void AddJob(Job job)
        {
            _db.Add(job);
            _db.SaveChanges();
        }
        public Job GetFirstOrDefault(int id)
        {
            var result = _db.Jobs.Where(Job => Job.Id == id).FirstOrDefault();
            return result;
        }
    }
}
