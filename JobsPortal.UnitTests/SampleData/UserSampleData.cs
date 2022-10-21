using JobsPortal.API.Models;
using JobsPortal.API.Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.UnitTests.SampleData
{
    public class UserSampleData
    {
        public AdminDTO GetAdminUserSampleData()
        {
            return new()
            {
                AdminUser = new()
                {
                    FirstName = "AdminName",
                    LastName = "AdminLastName",
                    UserType = API.Models.Enums.UserType.Admin,
                    Email = "test1@test.com",
                    City = "Rome",
                    Country = "Italy"
                },
                Id = 1
            };
        }
        public EmployerCompanyDTO GetEmployerCompanyUserSampleData()
        {
            return new()
            {
                CompanyPhone = "2138373830",
                CompanyName = "Some Company",
                EmployerCompanyUser = new()
                {
                    FirstName = "HRName",
                    LastName = "HRLastName",
                    UserType = API.Models.Enums.UserType.EmployerCompany,
                    Email = "test2@test.com",
                    City = "Rome",
                    Country = "Italy"
                }
            };
        }
        public JobSeekerDTO GetJobSeekerSampleData()
        {
            return new()
            {
                Qualification = "Graduation",
                DateOfBirth = new DateTime(1990, 08, 06),
                DesiredRole = API.Models.Enums.JobRole.DotNetDeveloper,
                Experience = "6 months to 1 year",
                JobSeekerUser = new()
                {
                    FirstName = "John",
                    LastName = "Smith",
                    UserType = API.Models.Enums.UserType.JobSeeker,
                    Email = "test1@test.com",
                    City = "Rome",
                    Country = "Italy"
                }
            };
        }
        
    public EmployerCompanyDTO GetRegisteredCompanySamplrDataForJob()
        {
            return new()
            {
                EmployerCompanyUser = new()
                {
                    FirstName = "HrName",
                    LastName = "HrLastName",
                    City = "Rome",
                    Country = "Italy",
                    Email = "hrname.lastname@test.com",
                    UserType = API.Models.Enums.UserType.EmployerCompany
                },
                Id = 1,
                CompanyName = "SomeCompanyName",
                CompanyPhone = "5792701782"
            };
        }
    }
}

