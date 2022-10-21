using JobsPortal.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.UnitTests.SampleData
{
    public class JobDetailsSampleData
    {
        public JobDetailsDTO GetJobDetailsSampleData()
        {
            var adminData = new UserSampleData().GetAdminUserSampleData();
            var employerData = new UserSampleData().GetEmployerCompanyUserSampleData();
            return new()
            {
                 Admin = adminData,
                 Details = "Some Job details",
                 AdminId = adminData.Id,
                 EmployerCompany = employerData,
                 EmployerCompanyId = employerData.Id,
                 Id = 1
            };
        }
    }
}
