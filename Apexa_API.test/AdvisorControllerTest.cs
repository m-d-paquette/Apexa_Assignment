using Apexa_API.Controllers;
using Application_Layer.Interfaces;
using Application_Layer.Services;
using Domain_Layer.Entities;
using Infrastructure_Layer.Caching;
using Infrastructure_Layer.Data;
using Infrastructure_Layer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Apexa_API.test
{
    public class AdvisorControllerTest
    {
        private AdvisorController _controller;
        public IAdvisorService _service;

        public AdvisorControllerTest()
        {
            // create the logger
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<AdvisorController>();

            // create the db context and repository
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "AdvisorsDb").Options;
            var dbContext = new DatabaseContext(options);
            var repository = new AdvisorRepository(dbContext);

            // create the cache
            var cache = new MruCache<int, Advisor>();

            // create the service and controller
            _service = new AdvisorService(repository, cache);
            _controller = new AdvisorController(_service, logger);
        }

        [Fact]
        public void GetAllAdvisors_Success()
        {
            //Arrange

            //Act
            var result = _controller.GetAllAdvisors();
            var resultType = result as OkObjectResult;
            var resultList = resultType.Value as List<Advisor>;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Advisor>>(resultType.Value);
            Assert.Equal(3, resultList.Count);
        }

        [Fact]
        public void GetAdvisorById_Success()
        {
            //Arrange
            int validId = 1;

            //Act
            var result = _controller.GetAdvisorById(validId);
            var resultType = result as OkObjectResult;
            var resultAdvisor = resultType.Value as Advisor;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Advisor>(resultType.Value);
            Assert.Equal(1, resultAdvisor.Id);
        }

        [Fact]
        public void CreateAdvisor_Success()
        {
            //Arrange
            Advisor newAdvisor = new Advisor()
            {
                Id = 0,
                Name = "Kevin Macdonald",
                SocialInsuranceNumber = "123123123"
            };

            //Act
            var result = _controller.CreateAdvisor(newAdvisor);
            var resultType = result as OkObjectResult;
            var resultAdvisor = resultType.Value as Advisor;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Advisor>(resultType.Value);
            Assert.Equal("Kevin Macdonald", resultAdvisor.Name);
            Assert.Equal("123123123", resultAdvisor.SocialInsuranceNumber);
        }

        [Fact]
        public void UpdateAdvisor_Success()
        {
            //Arrange
            Advisor updatedAdvisor = new Advisor()
            {
                Id = 2,
                Name = "Jane Deer",
                SocialInsuranceNumber = "456456456",
                PhoneNumber = "12345678"
            };

            //Act
            var result = _controller.UpdateAdvisor(updatedAdvisor);
            var resultType = result as OkObjectResult;
            var resultAdvisor = resultType.Value as Advisor;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Advisor>(resultType.Value);
            Assert.Equal("Jane Deer", resultAdvisor.Name);
            Assert.Equal("456456456", resultAdvisor.SocialInsuranceNumber);
            Assert.Equal("12345678", resultAdvisor.PhoneNumber);
        }

        [Fact]
        public void DeleteAdvisor_Success()
        {
            //Arrange
            int validId = 1;

            //Act
            var result = _controller.DeleteAdvisor(validId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }
    }
}