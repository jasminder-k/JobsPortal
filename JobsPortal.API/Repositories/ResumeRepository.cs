using JobsPortal.API.Data;
using JobsPortal.API.Models;
using JobsPortal.API.Repositories.IRepository;

namespace JobsPortal.API.Repositories
{
    public class ResumeRepository :Repository<Resume>, IResumeRepository
    {
        private readonly ApplicationDbContext _db;
        public ResumeRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Resume resume)
        {
            _db.Update(resume);
            _db.SaveChanges();
        }
        
        public void AddResume(Resume resume)
        {
            _db.Add(resume);
            _db.SaveChanges();
        }
        public Resume GetFirstOrDefault(int id)
        {
            var result = _db.Resumes.Where(jobdetail => jobdetail.Id == id).FirstOrDefault();
            return result;
        }
    }
}
