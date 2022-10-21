using JobsPortal.API.Models;

namespace JobsPortal.API.Repositories.IRepository
{
    public interface IResumeRepository
    {
        void Update(Resume resume);
        void AddResume(Resume resume);
        Resume GetFirstOrDefault(int id);
    }
}
