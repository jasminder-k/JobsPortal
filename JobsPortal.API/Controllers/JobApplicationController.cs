using AutoMapper;
using JobsPortal.API.Models;
using JobsPortal.API.Repositories;
using JobsPortal.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobApplicatonRepository _jobAppRepository;
        public JobApplicationController(IJobApplicatonRepository jobApplicatonRepository, IMapper mapper)
        {
            _jobAppRepository = jobApplicatonRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Retrieve all job applications of a job
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("GetAllJobApp")]
        public JsonResult JobApplications(int jobId)
        {
            try
            {
                if (!String.IsNullOrEmpty(jobId.ToString()))
                {
                    var jobApps = _jobAppRepository.GetAllJobApplicationByJobId(jobId);
                    var jobAppDTO = jobApps.Select(jobApp=>_mapper.Map<JobApplication, JobApplicationDTO>(jobApp));

                    if (jobAppDTO != null)
                        return new JsonResult(jobAppDTO);
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
        /// <summary>
        /// Create Job Application by a JobSeeker
        /// </summary>
        /// <param name="applications"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("SendJobApplication")]
        public IActionResult ApplyJob(JobApplicationDTO applicationDTO)
        {
            try
            {
                var application = _mapper.Map<JobApplicationDTO, JobApplication>(applicationDTO);
                if (application != null)
                {
                        _jobAppRepository.AddJobApp(application);
                        return Ok();
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
