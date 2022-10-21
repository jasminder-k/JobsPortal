using JobsPortal.API.Models;

namespace JobsPortal.API.Repositories.IRepository
{
    public interface IJobApplicatonRepository
    {
        void Update(JobApplication app);
        void AddJobApp(JobApplication app);
        List<JobApplication> GetAllJobApplicationByJobId(int jobId);
        List<JobApplication> GetAllJobApplicationsByJobSeekerById(int jobseekerId);
    }
}
