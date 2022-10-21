using AutoMapper;
using JobsPortal.API.Models;
using JobsPortal.API.Models.DTOModels;

namespace JobsPortal.API.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<JobDTO, Job>();
            CreateMap<JobDetailsDTO, JobDetails>();
            CreateMap<EmployerCompanyDTO, EmployerCompany>();
            CreateMap<AdminDTO, Admin>();
            CreateMap<UserDTO, User>();
            CreateMap<Job,JobDTO>();
            CreateMap<JobDetails, JobDetailsDTO>();
            CreateMap<EmployerCompany, EmployerCompanyDTO>();
            CreateMap<Admin, AdminDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<JobSeekerDTO,JobSeeker>();
            CreateMap<JobSeeker,JobSeekerDTO>();
            CreateMap<ResumeDTO,Resume>();
            CreateMap<Resume,ResumeDTO>();
            CreateMap<JobApplicationDTO, JobApplication>();
            CreateMap<JobApplication, JobApplicationDTO>();
        }
    }
}
