using JobsPortal.API.Models;

namespace JobsPortal.API.Repositories.IRepository
{
    public interface IJobSeekerRepository
    {
        void Update(JobSeeker jobSeeker);
        void AddJobSeeker(JobSeeker jobSeeker);
        JobSeeker GetFirstOrDefault(int id);
    }
}
