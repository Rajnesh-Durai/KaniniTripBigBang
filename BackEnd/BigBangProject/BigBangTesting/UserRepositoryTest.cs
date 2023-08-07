using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using BigBangProject.DataContext;
using BigBangProject.Model;
using BigBangProject.Repository.UserRepository;
using Microsoft.AspNetCore.Hosting;

namespace BigBangProject.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private UserRepository userRepository;
        private DbContextOptions<DBContext> dbContextOptions;
        private Mock<IWebHostEnvironment> hostEnvironmentMock;

        [SetUp]
        public void Setup()
        {
            // Initialize DbContextOptions for in-memory database
            dbContextOptions = new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Initialize mock for IWebHostEnvironment
            hostEnvironmentMock = new Mock<IWebHostEnvironment>();

            // Initialize UserRepository with mocked DbContext and IWebHostEnvironment
            var dbContextMock = new Mock<DBContext>(dbContextOptions);
            userRepository = new UserRepository(dbContextMock.Object, hostEnvironmentMock.Object);
        }

        [Test]
        public async Task GetAllDaySchedule_ReturnsListOfDaySchedules()
        {
            // Arrange
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.DaySchedules.Add(new DaySchedule { Id = 1, Daywise = 1, HotelName = "HotelVairam", SpotName = "Munnar" });
                dbContext.DaySchedules.Add(new DaySchedule { Id = 2, Daywise = 2, HotelName = "HotelUsthad", SpotName = "Alleppey" });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.GetAllDaySchedule();

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<DaySchedule>>(result);
                Assert.AreEqual(2, result.Count);
            }
        }
        [Test]
        public async Task GetAllBooking_ReturnsListOfBookings()
        {
            // Arrange
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.Bookings.Add(new Booking { Id = 1, StartDate = DateTime.Now, UserEmail = "raja@gmail.com", PackageId = 1, Status = true });
                dbContext.Bookings.Add(new Booking { Id = 2, StartDate = DateTime.Now, UserEmail = "rajnesh@gmail.com", PackageId = 2, Status = true });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.GetAllBooking();

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<Booking>>(result);
                Assert.AreEqual(2, result.Count);
            }
        }


        [Test]
        public async Task GetEmailById_ValidId_ReturnsEmailAddress()
        {
            // Arrange
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.Database.EnsureCreated(); // Ensure the database is created
                dbContext.Users.Add(new User { Id = 1, Email = "test@example.com", Name = "User 1", IsActive = true });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.GetEmailById(1);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual("test@example.com", result);
            }
        }

        [Test]
        public async Task GetAllUsers_ReturnsListOfUsers()
        {
            // Arrange
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.Users.Add(new User { Id = 1, Email = "test1@example.com", Name = "User 1", IsActive = true });
                dbContext.Users.Add(new User { Id = 2, Email = "test2@example.com", Name = "User 2", IsActive = true });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.GetAllUsers();

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<User>>(result);
                Assert.AreEqual(2, result.Count);
            }
        }

        [Test]
        public async Task GetSpotByName_ValidName_ReturnsSpot()
        {
            // Arrange
            var spotName = "Spot 1";
            var spotAddress = "Address 1";
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.SightSeeings.Add(new SightSeeing { SpotName = spotName, SpotAddress = spotAddress, DurationPerHour = 9 });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.GetSpotByName(spotAddress);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(spotName, result.SpotName);
                Assert.AreEqual(spotAddress, result.SpotAddress);
            }
        }

        [Test]
        public async Task GetHotelByName_ValidName_ReturnsHotel()
        {
            // Arrange
            var hotelName = "Hotel 1";
            var hotelAddress = "Address 1";
            var description = "Traditional";
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.Hotels.Add(new Hotel { HotelName = hotelName, HotelFeatures = hotelAddress, FoodDescription = description });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.GetHotelByName(hotelName);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(hotelName, result.HotelName);
                Assert.AreEqual(hotelAddress, result.HotelFeatures);
                Assert.AreEqual(description, result.FoodDescription);
            }
        }

        [Test]
        public async Task GetAllPackage_ReturnsListOfPackages()
        {
            // Arrange
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.Packages.Add(new Package { Id = 1, PackageName = "Package 1", LocationId = 1, Iternary = "1N Munnar", PricePerPerson = 6000, NumberOfDays = 7 });
                dbContext.Packages.Add(new Package { Id = 2, PackageName = "Package 2", LocationId = 2, Iternary = "1N Munnar", PricePerPerson = 7000, NumberOfDays = 4 });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.GetAllPackage();

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<Package>>(result);
                Assert.AreEqual(2, result.Count);
            }
        }

        [Test]
        public async Task GetPackage_ValidLocationId_ReturnsListOfPackages()
        {
            // Arrange
            var locationId = 1;
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.Packages.Add(new Package { Id = 1, PackageName = "Package 1", LocationId = locationId, Iternary = "1N Munnar", PricePerPerson = 6000, NumberOfDays = 7 });
                dbContext.Packages.Add(new Package { Id = 2, PackageName = "Package 2", LocationId = 2, Iternary = "1N Munnar", PricePerPerson = 5000, NumberOfDays = 4 });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.GetPackage(locationId);

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<Package>>(result);
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(locationId, result.First().LocationId);
            }
        }


        [Test]
        public async Task GetAllHotels_ReturnsListOfHotels()
        {
            // Arrange
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.Hotels.Add(new Hotel { Id = 1, HotelName = "Hotel 1", HotelFeatures = "Wifi", FoodDescription = "Traditinal" });
                dbContext.Hotels.Add(new Hotel { Id = 2, HotelName = "Hotel 2", HotelFeatures = "Wifi", FoodDescription = "Traditinal" });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.GetAllHotels();

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<Hotel>>(result);
                Assert.AreEqual(2, result.Count);
            }
        }

        [Test]
        public async Task GetAllSightSeeing_ReturnsListOfSightSeeing()
        {
            // Arrange
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.SightSeeings.Add(new SightSeeing { Id = 1, SpotAddress = "SightSeeing 1",SpotName="Munnar",DurationPerHour=3 });
                dbContext.SightSeeings.Add(new SightSeeing { Id = 2, SpotAddress = "SightSeeing 2", SpotName = "Munnar", DurationPerHour = 3 });
                dbContext.SaveChanges();
            }

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.GetAllSightSeeing();

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<SightSeeing>>(result);
                Assert.AreEqual(2, result.Count);
            }
        }

        [Test]
        public async Task GetDayScheduleForPackage_ValidPackageId_ReturnsListOfDaySchedules()
        {
            // Arrange
            var packageId = 1;
            using (var dbContext = new DBContext(dbContextOptions))
            {
                // Add test data to the in-memory database
                dbContext.DaySchedules.Add(new DaySchedule { Id = 1, PackageId = 1, HotelName = "HotelVairam", SpotName = "Munnar" });
                dbContext.DaySchedules.Add(new DaySchedule { Id = 2, PackageId = 2, HotelName = "HotelVairam", SpotName = "Munnar" });
                dbContext.SaveChanges();

                var userRepository = new UserRepository(dbContext, null);

                // Act
                var result = await userRepository.GetDayScheduleForPackage(packageId);

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<DaySchedule>>(result);
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(packageId, result.First().PackageId);
            }
        }

        [Test]
        public async Task BookPackage_ValidBooking_ReturnsListOfBookings()
        {
            // Arrange
            var booking = new Booking { Id = 1, StartDate = DateTime.Now, UserEmail = "raja@gmail.com", PackageId = 1, Status = true };

            // Act
            using (var dbContext = new DBContext(dbContextOptions))
            {
                var userRepository = new UserRepository(dbContext, null);
                var result = await userRepository.BookPackage(booking);

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<Booking>>(result);
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(booking.Id, result.First().Id);
            }
        }

        /*        [Test]
                public async Task GetAllBooking_ReturnsListOfBookings()
                {
                    // Arrange
                    using (var dbContext = new DBContext(dbContextOptions))
                    {
                        // Add test data to the in-memory database
                        dbContext.Bookings.Add(new Booking { Id = 1, StartDate = DateTime.Now, UserEmail = "rajnesh@gmail.com", PackageId = 1, Status = true });
                        dbContext.Bookings.Add(new Booking { Id = 2, StartDate = DateTime.Now, UserEmail = "rajeesh@gmail.com", PackageId = 2, Status = true });
                        dbContext.SaveChanges();
                    }

                    // Act
                    var result = await userRepository.GetAllBooking();

                    // Assert
                    Assert.NotNull(result);
                    Assert.IsInstanceOf<List<Booking>>(result);
                    Assert.AreEqual(2, result.Count);
                }*/
    }
}
