using AutoMapper;
using JobsPortal.API.Models;
using JobsPortal.API.Models.DTOModels;
using JobsPortal.API.Models.Enums;
using JobsPortal.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobSeekerRepository _jobSeekerRepository;
        public JobSeekerController(IJobSeekerRepository jobSeekerRepository,IMapper mapper)
        {
            _mapper = mapper;
            _jobSeekerRepository = jobSeekerRepository;
        }
        /// <summary>
        ///  self-registration of JobSeeker
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("Register")]
        public IActionResult Register(JobSeekerDTO jobSeekerDTO)
        {
            try
            {
                var jobSeeker = _mapper.Map<JobSeekerDTO, JobSeeker>(jobSeekerDTO);
                if(jobSeeker != null)
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

        [HttpGet("ProfileJobSeeker")]
        public JsonResult GetJobSeekerProfile(int id)
        {
            try
            {
                if (!String.IsNullOrEmpty(id.ToString()))
                {
                    var profile = _jobSeekerRepository.GetFirstOrDefault(id);
                    var profileDTO = _mapper.Map<JobSeeker, JobSeekerDTO>(profile);
                    if (profileDTO != null)
                        return new JsonResult(profileDTO);
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
    }
}
