using JobsPortal.API.Models;

namespace JobsPortal.API.Repositories.IRepository
{
    public interface IJobDetailsRepository
    {
        void Update(JobDetails jobdetails);
        void AddJobDetails(JobDetails jobdetails, int employeeId);
        //JobDetails GetFirstOrDefault(int id);
        JobDetails GetFirstOrDefault(int jobDetailsId, int adminId);
    }
}
