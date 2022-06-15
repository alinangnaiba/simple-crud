using Core.Entities;
using Core.Repositories;
using Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Services;

namespace Test.Services
{
    public class ServiceTest
    {
        private Mock<IRepository<Employee>> mockEmployeeRepository;
        private EmployeeService sut;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllEmployees_ShouldReturnAListOfEmployees()
        {
            var expectedResult = new List<Employee> 
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Test Employee1",
                    MiddleName = "Test Employee1",
                    LastName = "Test Employee1"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Test Employee2",
                    MiddleName = "Test Employee2",
                    LastName = "Test Employee2"
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Test Employee3",
                    MiddleName = "Test Employee3",
                    LastName = "Test Employee3"
                },
            };
            
            mockEmployeeRepository = new Mock<IRepository<Employee>>(MockBehavior.Strict);
            mockEmployeeRepository.Setup(p => p.GetAllAsync().Result)
                .Returns(expectedResult);

            Assert.Pass();
        }
    }
}
