using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBangProject.DataContext;
using BigBangProject.Model;
using BigBangProject.Repository.AdminRepository;

[TestFixture]
public class AdminRepositoryTests
{
    private DbContextOptions<DBContext> _dbContextOptions;

/*    [SetUp]
    public void Setup()
    {
        // Setup the in-memory database context
        _dbContextOptions = new DbContextOptionsBuilder<DBContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        // Seed the in-memory database with some test data
        using (var dbContext = new DBContext(_dbContextOptions))
        {
            dbContext.Users.AddRange(new List<User>
            {
                new User { Id = 1, Name = "User1", IsActive = false },
                new User { Id = 2, Name = "User2", IsActive = true },
                new User { Id = 3, Name = "User3", IsActive = false },
            });
            dbContext.SaveChanges();
        }
    }*/

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        // Setup the in-memory database context and seed it only once
        _dbContextOptions = new DbContextOptionsBuilder<DBContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        using (var dbContext = new DBContext(_dbContextOptions))
        {
            dbContext.Users.AddRange(new List<User>
            {
                new User { Id = 1, Name = "User1", IsActive = false },
                new User { Id = 2, Name = "User2", IsActive = true },
                new User { Id = 3, Name = "User3", IsActive = false },
            });
            dbContext.SaveChanges();
        }
    }

    // Test case for GetRequest method
  
    [Test]
    public async Task GetRequest_ReturnsInactiveUsers()
    {
        // Arrange
        using (var dbContext = new DBContext(_dbContextOptions))
        {
            var adminRepository = new AdminRepository(dbContext, null);

            // Act
            var result = await adminRepository.GetRequest();

            // Assert
            Assert.AreEqual(2, result.Count, "Number of inactive users should be 2.");

            // Verify if all users in the result are inactive
            Assert.IsTrue(result.All(u => u.IsActive == false), "All users should be inactive.");

            // Print user details to help identify the issue
            foreach (var user in result)
            {
                Console.WriteLine($"User ID: {user.Id}, Name: {user.Name}, IsActive: {user.IsActive}");
            }
        }
    }

    // Test case for PutRequest method
    [Test]
    public async Task PutRequest_ValidUserIdAndUser_UpdatesUserAndReturnsAllUsers()
    {
        // Arrange
        using (var dbContext = new DBContext(_dbContextOptions))
        {
            var adminRepository = new AdminRepository(dbContext, null);
            var userId = 1;

            // Act: Fetch the user entity using FindAsync
            var userToUpdate = await dbContext.Users.FindAsync(userId);

            // Assert: Ensure the user entity is not null
            Assert.NotNull(userToUpdate, $"User with ID {userId} should exist in the database.");

            // Update the user entity
            userToUpdate.Name = "UpdatedUser";
            userToUpdate.IsActive = true;

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            // Act: Fetch all users after the update
            var result = await adminRepository.PutRequest(userId, userToUpdate);

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.Any(u => u.Name == "UpdatedUser" && u.IsActive == true));
        }
    }


    // Test case for DeleteRequest method
    [Test]
    public async Task DeleteRequest_ValidUserId_RemovesUserAndReturnsAllUsers()
    {
        // Arrange
        using (var dbContext = new DBContext(_dbContextOptions))
        {
            var adminRepository = new AdminRepository(dbContext, null);
            var userId = 1;

            // Act
            var result = await adminRepository.DeleteRequest(userId);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsFalse(result.Any(u => u.Id == 1));
        }
    }
}

