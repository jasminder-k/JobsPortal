﻿using AutoMapper;
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
    public class JobSeekerControllerUnitTests
    {
        private Mock<IJobSeekerRepository> _jobSeekerRepo;
        public JobSeekerControllerUnitTests()
        {
            _jobSeekerRepo = new Mock<IJobSeekerRepository>();
        }
        /// <summary>
        /// Tests for successful registration
        /// </summary>
        [Fact]
        public void RegisterJobSeeker_OkTest()
        {
            //Arrange
            var obj = new UserSampleData().GetJobSeekerSampleData();
            var config = new MapperConfiguration(cfg => {
  
                cfg.CreateMap<JobSeekerDTO, JobSeeker>();
                cfg.CreateMap<UserDTO, User>();

            });
            var mockMapper = config.CreateMapper();

            var controller = new JobSeekerController( _jobSeekerRepo.Object, mockMapper);

            //Act
            var result = controller.Register(obj);

            //Assert
            var actionResult = result as OkResult;

            Assert.NotNull(actionResult);
        }
        /// <summary>
        /// Tests for null data
        /// </summary>
        [Fact]
        public void RegisterJobSeeker_BadRequest_Test()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<JobSeekerDTO, JobSeeker>();
                cfg.CreateMap<UserDTO, User>();

            });
            var mockMapper = config.CreateMapper();

            var controller = new JobSeekerController(_jobSeekerRepo.Object, mockMapper);

            //Act
            var result = controller.Register(null);

            //Assert
            var actionResult = result as BadRequestResult;

            Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }
        /// <summary>
        /// Tests for wrong mapping
        /// </summary>
        [Fact]
        public void RegisterJobSeeker_Exception_Test()
        {
            //Arrange
            var obj = new UserSampleData().GetJobSeekerSampleData();
            //obj.CompanyName = String.Empty;
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<EmployerCompanyDTO, EmployerCompany>();
                cfg.CreateMap<UserDTO,User>();

            });
            var mockMapper = config.CreateMapper();

            var controller = new JobSeekerController(_jobSeekerRepo.Object, mockMapper);

            //Act
            var result = Assert.Throws<Exception>(() => controller.Register(obj));

            //Assert
            Assert.IsType<Exception>(result);
        }
    }
}
