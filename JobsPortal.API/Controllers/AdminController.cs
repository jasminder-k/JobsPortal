using AutoMapper;
using JobsPortal.API.Models;
using JobsPortal.API.Models.DTOModels;
using JobsPortal.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobSeekerRepository _jobSeekerRepository;
        private readonly IEmployerCompanyRepository _employerCompanyRepository;
        public AdminController(IJobSeekerRepository jobSeekerRepository, IEmployerCompanyRepository employerCompanyRepository, IMapper mapper)
        {
            _jobSeekerRepository = jobSeekerRepository;
            _employerCompanyRepository = employerCompanyRepository;
            _mapper = mapper;
        }
        /// <summary>
        ///  self-registration of JobSeeker or by back office
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("RegisterJobSeeker")]
        public IActionResult Register(JobSeekerDTO jobSeekerDTO)
        {
            try
            {
                var jobSeeker = _mapper.Map<JobSeekerDTO,JobSeeker>(jobSeekerDTO);
                if (jobSeeker != null)
                {
                    _jobSeekerRepository.AddJobSeeker(jobSeeker);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        ///  Registration of Employer Company by back office
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("RegisterEmployerCompany")]
        public IActionResult Register(EmployerCompanyDTO employerCompanyDTO)
        {
            try
            {
                var employerCompany = _mapper.Map<EmployerCompanyDTO,EmployerCompany>(employerCompanyDTO);
                if (employerCompany != null)
                {
                    _employerCompanyRepository.AddEmployerCompany(employerCompany);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
