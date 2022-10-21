using AutoMapper;
using JobsPortal.API.Models;
using JobsPortal.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDetailsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobDetailsRepository _jobDetailsRepository;
        private readonly IEmployerCompanyRepository _employerCompanyRepository;
        public JobDetailsController(IJobDetailsRepository jobDetailsRepository, IMapper mapper, IEmployerCompanyRepository employerCompanyRepository)
        {
            _mapper = mapper;
            _jobDetailsRepository = jobDetailsRepository;
            _employerCompanyRepository = employerCompanyRepository ;
        }
        [HttpGet("GetDetails")]
        public JsonResult JobDetails(int id, int adminId)
        {
            try
            {
                //to-do get employer id and then create jobdetails
                if (!String.IsNullOrEmpty(id.ToString()))
                {
                    var jobDetails = _jobDetailsRepository.GetFirstOrDefault(id,adminId);
                    var jobDetailsDTO = _mapper.Map<JobDetails, JobDetailsDTO>(jobDetails);

                    if (jobDetailsDTO != null)
                        return new JsonResult(jobDetailsDTO);
                    return new JsonResult(NotFound());
                }
                else
                    return new JsonResult(BadRequest());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        [HttpPost("CreateJobDetails")]
        public IActionResult AddJobDetails(JobDetailsDTO jobDetailsDTO, int employeeId)
        {
            try
            {
                var jobDetails = _mapper.Map<JobDetailsDTO,JobDetails>(jobDetailsDTO);
                if (jobDetails != null)
                { 
                        _jobDetailsRepository.AddJobDetails(jobDetails, employeeId);
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
