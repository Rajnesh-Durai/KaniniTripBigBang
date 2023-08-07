using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using BigBangProject.DataContext;
using BigBangProject.Model;
using BigBangProject.Repository.AgentRepository;

namespace KaniniBigBangTesting
{
    [TestFixture]
    public class AgentRepositoryTests
    {
        private DbContextOptions<DBContext> _dbContextOptions;

        [SetUp]
        public void Setup()
        {
            // Initialize the DbContextOptions with an in-memory database provider
            _dbContextOptions = new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the in-memory database after each test
            using (var dbContext = new DBContext(_dbContextOptions))
            {
                dbContext.Database.EnsureDeleted();
            }
        }

        [Test]
        public async Task TestAgentRepositoryMethods()
        {
            // Arrange
            using (var dbContext = new DBContext(_dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.Locations.Add(new Location { Id = 1, LocationName = "TestLocation" });

                // Initialize the SightSeeing entity with required properties
                dbContext.SightSeeings.Add(new SightSeeing
                {
                    Id = 1,
                    LocationId = 1,
                    DurationPerHour = 2, // Example value for DurationPerHour
                    SpotAddress = "TestAddress", // Example value for SpotAddress
                    SpotName = "TestSpot" // Example value for SpotName
                });

                // Initialize the Hotel entity with required properties
                dbContext.Hotels.Add(new Hotel
                {
                    Id = 1,
                    SightSeeingId = 1,
                    FoodDescription = "TestFoodDescription", // Example value for FoodDescription
                    HotelName = "TestHotel" // Example value for HotelName
                });

                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new DBContext(_dbContextOptions))
            {
                var agentRepository = new AgentRepository(dbContext);

                // Act & Assert
                // Test GetIdByLocationName method
                var locationId = await agentRepository.GetIdByLocationName("TestLocation");
                Assert.AreEqual(1, locationId);

                // Test GetSpotbyLocationId method
                var spotList = await agentRepository.GetSpotbyLocationId(1);
                Assert.AreEqual(1, spotList.Count);

                // Test GetHotelbySpotId method
                var hotelList = await agentRepository.GetHotelbySpotId(1);
                Assert.AreEqual(1, hotelList.Count);

                // Test PostPackage method
                var package = new Package
                {
                    Iternary = "TestIternary", // Example value for Iternary
                    NumberOfDays = 5, // Example value for NumberOfDays
                    PackageName = "TestPackage", // Example value for PackageName
                    PricePerPerson = 100 // Example value for PricePerPerson
                };

                var packages = await agentRepository.PostPackage(package);
                Assert.AreEqual(1, packages.Count);

                // Test PostDaySchedule method
                var schedule = new DaySchedule
                {
                    HotelName = "TestHotel", // Example value for HotelName
                    SpotName = "TestSpot" // Example value for SpotName
                };

                var daySchedules = await agentRepository.PostDaySchedule(schedule);
                Assert.AreEqual(1, daySchedules.Count);
            }
        }
    }
}
