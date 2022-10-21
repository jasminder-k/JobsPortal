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
    public class EmployerCompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployerCompanyRepository _employerCompanyRepository;
        public EmployerCompanyController(IEmployerCompanyRepository employerCompanyRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employerCompanyRepository = employerCompanyRepository;
        }
        /// <summary>
        ///  self-registration of JobSeeker or by back office
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("Register")]
        public IActionResult Register(EmployerCompanyDTO employerCompanyDTO)
        {
            try
            {
                var employerCompany = _mapper.Map<EmployerCompanyDTO, EmployerCompany>(employerCompanyDTO);
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

        [HttpGet("ProfileEmployerCompany")]
        public JsonResult GetEmployerCompanyProfile(int id)
        {
            try
            {
                if (!String.IsNullOrEmpty(id.ToString()))
                {
                    var profile = _employerCompanyRepository.GetFirstOrDefault(id);
                    var profileDTO = _mapper.Map<EmployerCompany, EmployerCompanyDTO>(profile);
                    if (profile != null)
                        return new JsonResult(profile);
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
