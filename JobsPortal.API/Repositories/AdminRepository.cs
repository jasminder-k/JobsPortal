using JobsPortal.API.Data;
using JobsPortal.API.Models;
using JobsPortal.API.Repositories.IRepository;

namespace JobsPortal.API.Repositories
{
    public class AdminRepository :Repository<Admin>, IAdminRepository
    {
        private readonly ApplicationDbContext _db;
        public AdminRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Admin admin)
        {
            _db.Update(admin);
            _db.SaveChanges();
        }
    }
}
