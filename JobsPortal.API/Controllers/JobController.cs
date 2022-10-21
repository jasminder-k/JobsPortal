using JobsPortal.API.Models;
using JobsPortal.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobsPortal.API.Models.Enums;
using AutoMapper;

namespace JobsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepository;
        private readonly IEmployerCompanyRepository _employerCompanyRepository;
        public JobController(IJobRepository jobRepository, IEmployerCompanyRepository employerCompanyRepository,IMapper mapper)
        {
            _jobRepository = jobRepository;
            _employerCompanyRepository = employerCompanyRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Checks if employer company is registered and checks also the role of User == Admin
        /// if user is Admin then he/she can add vacancy
        /// </summary>
        /// <param name="vacancy"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("CreateJob")]
        public IActionResult AddJob(JobDTO vacancy)
        {
            try
            {
                var job = _mapper.Map<Job>(vacancy);
                var companyRegistered = /*_employerCompanyRepository.GetFirstOrDefault(job)*/new EmployerCompany();
                if (companyRegistered != null )
                    //&&
                    //vacancy.Admin.AdminUser.UserType == UserType.Admin)
                {            
                    _jobRepository.AddJob(job);
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult JobInformation(int id)
        {
            try
            {
                if (!String.IsNullOrEmpty(id.ToString()))
                {
                    var jobInfo = _jobRepository.GetFirstOrDefault(id);
                    var jobinfoDTO = _mapper.Map<Job,JobDTO>(jobInfo);
                    
                    if(jobinfoDTO != null)
                        return Ok(jobinfoDTO);
                    
                }
                return NotFound();
                //else
                //    return BadRequest();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
