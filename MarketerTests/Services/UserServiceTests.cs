using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marketer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Marketer.Data;
using Marketer.Interfaces;
using Marketer.Models;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace Marketer.Services.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
     
        [TestMethod()]
        [ExpectedException(typeof(Exception), "Invalid client request")]
        public async Task LoginTest_NullUserLogin_ThrowsException()
        {
            // Arrange
            var tokenServiceMock = new Mock<ITokenService>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(CreateMockDataContext(), tokenServiceMock.Object, mapperMock.Object);

            // Act
            await userService.Login(null, CancellationToken.None);

            // Assert
            // Expects an exception to be thrown
        }

        [TestMethod()]
        public async Task RegisterTest_ValidUserRegister_ReturnsRegistredResponse()
        {
            // Arrange
            var userRegister = new UserRegister { Username = "TestUser", Email = "test@example.com", Password = "TestPassword" };
            var tokenServiceMock = new Mock<ITokenService>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(CreateMockDataContext(), tokenServiceMock.Object, mapperMock.Object);

            // Act
            var result = await userService.Register(userRegister, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userRegister.Username, result.Username);
            Assert.AreEqual(userRegister.Email, result.Email);
            Assert.IsNotNull(result.Id);
        }


        private DataContext CreateMockDataContext()
        {
            // Create options for an in-memory database
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            // Create a mock of the DataContext using the in-memory database options
            var mockDataContext = new Mock<DataContext>(options);

            // Configure any additional setup for the mock as needed
            // For example, you can set up specific DbSet<T> or other methods

            // Return the mock object's instance
            return mockDataContext.Object;
        }
    }
}

