using JobsPortal.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.UnitTests.SampleData
{
    public class JobSampleData
    {
        public JobDTO GetJobDTOSampleData()
        {
            var adminData = new UserSampleData().GetAdminUserSampleData();
            var jobDetailsData = new JobDetailsSampleData().GetJobDetailsSampleData();
            return new()
            {
                Admin = adminData,
                AdminId = adminData.Id,
                NumberVacancies = 2,
                City = "Rome",
                Country = "Italy",
                CreatedOn = DateTime.Now,
                Description = "Some Description",
                Experience = "1 to 2 years",
                //JobDetails = jobDetailsData,
                JobType = API.Models.Enums.JobType.FullTime,
                Salary = 167827,
                Skill = ".net developer",
                Title = "Software developer"
            };
        }
    }
}
