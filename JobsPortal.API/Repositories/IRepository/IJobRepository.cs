using JobsPortal.API.Models;

namespace JobsPortal.API.Repositories.IRepository
{
    public interface IJobRepository
    {
        void Update(Job job);
        void AddJob(Job job);
        Job GetFirstOrDefault(int id);
    }
}
