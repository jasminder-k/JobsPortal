using AutoMapper;
using JobsPortal.API.Models;
using JobsPortal.API.Models.DTOModels;
using JobsPortal.API.Repositories;
using JobsPortal.API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsPortal.API.Controllers
{
    [Route("api/JobSeeker/{id}/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IResumeRepository _resumeRepository;
        public ResumeController(IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Retrieve resume by idb
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("{resumeId}")]
        public JsonResult GetResume(int resumeId)
        {
            try
            {
                if (!String.IsNullOrEmpty(resumeId.ToString()))
                {
                    var resume = _resumeRepository.GetFirstOrDefault(resumeId);
                    var resumeDTO = _mapper.Map<Resume, ResumeDTO>(resume);

                    if (resumeDTO != null)
                        return new JsonResult(resumeDTO);
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
        /// Send resume
        /// </summary>
        /// <param name="applications"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        public IActionResult SpontaneousCandidature(ResumeDTO resumeDTO)
        {
            try
            {
                var resume = _mapper.Map<ResumeDTO, Resume>(resumeDTO);
                if (resume != null)
                {
                        _resumeRepository.AddResume(resume);
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
