using JobsPortal.API.Repositories.IRepository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.UnitTests.Controllers
{
    public class AdminControllerUnitTests
    {
        private Mock<IEmployerCompanyRepository> _companyrepository;
        private Mock<IJobSeekerRepository> _jobSeekerRepo;
        public AdminControllerUnitTests()
        {
            _jobSeekerRepo = new Mock<IJobSeekerRepository>();
            _companyrepository = new Mock<IEmployerCompanyRepository>();
        }
    }
}
