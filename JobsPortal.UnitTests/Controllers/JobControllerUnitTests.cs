using AutoMapper;
using JobsPortal.API.Controllers;
using JobsPortal.API.Models;
using JobsPortal.API.Models.DTOModels;
using JobsPortal.API.Repositories.IRepository;
using JobsPortal.UnitTests.SampleData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.UnitTests.Controllers
{
    public class JobControllerUnitTests
    {
        private Mock<IJobRepository> _jobrepository;
        private Mock<IEmployerCompanyRepository> _companyrepository;
        private Mock<IMapper> _mapper;
        public JobControllerUnitTests()
        {
            _jobrepository = new Mock<IJobRepository>();
            _companyrepository = new Mock<IEmployerCompanyRepository>();
            _mapper = new Mock<IMapper>();
        }
        [Fact]
        public void AddJobs_OkTest()
        {
            //Arrange
            var obj = new JobSampleData().GetJobDTOSampleData();
            var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<JobDTO, Job>();
                    cfg.CreateMap<JobDetailsDTO, JobDetails>();
                    cfg.CreateMap<EmployerCompanyDTO, EmployerCompany>();
                    cfg.CreateMap<AdminDTO, Admin>();
                     cfg.CreateMap<UserDTO, User>();
               
            });
            var mockMapper = config.CreateMapper();

            var controller = new JobController(_jobrepository.Object, _companyrepository.Object,mockMapper);

            //Act
            var result = controller.AddJob(obj);

            //Assert
            var actionResult = result as OkResult;

            Assert.NotNull(actionResult);
        }

        [Fact]
        public void AddJobs_BadRequest_Test()
        {
            //Arrange
            var obj = new JobSampleData().GetJobDTOSampleData();
           
            var controller = new JobController(_jobrepository.Object, _companyrepository.Object,_mapper.Object);

            //Act
            var result = controller.AddJob(obj);

            //Assert
            var actionResult = result as BadRequestResult;
            Assert.NotNull(actionResult);
        }
        [Fact]
        public void AddJobs_Exception_Test()
        {
            //Arrange
            var obj = new JobDTO();
            var controller = new JobController(_jobrepository.Object, _companyrepository.Object,_mapper.Object);

            //Act
            var result = Assert.Throws<Exception>(() => controller.AddJob(obj));

            //Assert
            Assert.IsType<Exception>(result);
        }
        [Fact]
        public void JobInformation_Ok_Test()
        {
            //Arrange
            var id = 1;
            var controller = new JobController(_jobrepository.Object, _companyrepository.Object,_mapper.Object);
            //Act
            var result = controller.JobInformation(id) as OkObjectResult;

            //Assert
            Assert.Equal(StatusCodes.Status200OK,result.StatusCode);
        }
        [Fact]
        public void JobInformation_NotFound_Test()
        {
            //Arrange
            var id = 2;
            var controller = new JobController(_jobrepository.Object, _companyrepository.Object, _mapper.Object);

            //Act
            var result =  controller.JobInformation(id) as NotFoundResult;

            //Assert
            Assert.Equal(StatusCodes.Status404NotFound,result.StatusCode);
        }
        //[Fact]
        //public void JobInformation_BadRequest_Test()
        //{
        //    //Arrange
        //    var controller = new JobController(_jobrepository.Object, _companyrepository.Object);

        //    //Act
        //    var result = controller.JobInformation(0) as BadRequestResult;

        //    //Assert
        //    Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        //}
        [Fact]
        public void JobInformation_Exception_Test()
        {
            //Arrange
            var id = 1;
            var controller = new JobController(_jobrepository.Object, _companyrepository.Object,_mapper.Object);

            //Act
            var result = Assert.Throws<Exception>(() => controller.JobInformation(id));

            //Assert
            Assert.IsType<Exception>(result) ;
        }
    }
}
