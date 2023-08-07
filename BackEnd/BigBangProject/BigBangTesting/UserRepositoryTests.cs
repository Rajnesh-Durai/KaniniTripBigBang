using BigBangProject.DataContext;
using BigBangProject.Model;
using BigBangProject.Repository.UserRepository;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaniniBigBangTesting
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private List<Location> testDataLocations = new List<Location>
        {
            new Location { Id = 1, LocationName = "Location 1" },
            new Location { Id = 2, LocationName = "Location 2" },
            new Location { Id = 3, LocationName = "Location 3" }
        };

        private List<Package> testDataPackages = new List<Package>
        {
            new Package { Id = 1, PackageName = "Package 1", LocationId = 1 },
            new Package { Id = 2, PackageName = "Package 2", LocationId = 1 },
            new Package { Id = 3, PackageName = "Package 3", LocationId = 2 }
        };

        private List<User> testDataUsers = new List<User>
        {
            new User { Id = 1, Name = "User 1", IsActive = false },
            new User { Id = 2, Name = "User 2", IsActive = false },
            new User { Id = 3, Name = "User 3", IsActive = false }
        };

        private Mock<DBContext> dbContextMock;
        private Mock<IWebHostEnvironment> webHostEnvironmentMock;

        [SetUp]
        public void Setup()
        {
            dbContextMock = new Mock<DBContext>();
            webHostEnvironmentMock = new Mock<IWebHostEnvironment>();

            SetupMockDbContext();
        }

        private void SetupMockDbContext()
        {
            var locationsDbSetMock = testDataLocations.AsQueryable().BuildMockDbSet();
            var packagesDbSetMock = testDataPackages.AsQueryable().BuildMockDbSet();
            var usersDbSetMock = testDataUsers.AsQueryable().BuildMockDbSet();

            /*dbContextMock.Setup(m => m.Locations).Returns(locationsDbSetMock.Object);*//*
            dbContextMock.Setup(m => m.Packages).Returns(packagesDbSetMock.Object);
            dbContextMock.Setup(m => m.Users).Returns(usersDbSetMock.Object);*/
        }

        [Test]
        public async Task GetLocation_Should_ReturnListOfLocations()
        {
            // Arrange
            var userRepository = new UserRepository(dbContextMock.Object, webHostEnvironmentMock.Object);

            // Act
            var result = await userRepository.GetLocation();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(testDataLocations.Count, result.Count);
        }

        [Test]
        public async Task GetLocation_Should_ThrowException_When_LocationListIsEmpty()
        {
            // Arrange
            dbContextMock.Setup(m => m.Locations).Returns((new List<Location>()).AsQueryable().BuildMockDbSet().Object);
            var userRepository = new UserRepository(dbContextMock.Object, webHostEnvironmentMock.Object);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await userRepository.GetLocation());
        }

    }
}
