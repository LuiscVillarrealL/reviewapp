using Microsoft.EntityFrameworkCore;
using Moq;
using RestaurantReviewApp.Models;
using RestaurantReviewApp.Persistence;
using RestaurantReviewApp.Services;
using UserReviewApp.Services;
using Xunit;

public class UserServiceTests
{
    private readonly UserService _userService;
    private readonly ApplicationDbContext _dbContext;

    public UserServiceTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique DB for each test
            .Options;

        _dbContext = new ApplicationDbContext(options);
        _userService = new UserService(_dbContext);
    }

    [Fact]
    public async Task AddUserAsync_ShouldAddUser()
    {
        // Arrange
        var user = new User { Name = "Test User", Email = "test@example.com", Phone = 12345670 };

        // Act
        var addedUser = await _userService.AddUserAsync(user);

        // Assert
        Assert.NotNull(addedUser);
        Assert.Equal("Test User", addedUser.Name);
    }

    [Fact]
    public async Task GetAllUsersAsync_ShouldReturnUsers()
    {
        // Arrange
        _dbContext.Users.Add(new User { Name = "User1", Email = "user1@example.com", Phone = 1234567890 });
        _dbContext.Users.Add(new User { Name = "User2", Email = "user2@example.com", Phone = 0987654321 });
        await _dbContext.SaveChangesAsync();

        // Act
        var users = await _userService.GetAllUsersAsync();

        // Assert
        Assert.Equal(2, users.Count());
    }


    [Fact]
    public async Task DeleteUsersAsync_ShouldReturnNoUsers()
    {

        User user = new User { Name = "User1", Email = "user1@example.com", Phone = 1234567890 };
        _dbContext.Users.Add(user);
        _dbContext.Users.Remove(user);


        await _dbContext.SaveChangesAsync();

        

        // Act
        var users = await _userService.GetAllUsersAsync();

        // Assert
        Assert.Equal(0, users.Count());
    }

    [Fact]
    public async Task UpdateUsersAsync_ShouldReturnUser()
    {


        // Arrange
        var user = new User { Name = "Test User", Email = "test@example.com", Phone = 12345670 };

        // Act
        var addedUser = await _userService.AddUserAsync(user);

        user.Name = "updatedName";
        user.Email = "updatedEmail";
        user.Phone = 111;

        _dbContext.Users.Update(user);

        await _dbContext.SaveChangesAsync();



        // Act
        var userSearch = await _userService.GetUserByIdAsync(user.Id);

     

        // Assert
        Assert.Equal("updatedName", userSearch.Name);
        Assert.Equal("updatedEmail", userSearch.Email);
        Assert.Equal(111, userSearch.Phone);
    }



    public void Dispose()
    {
        _dbContext.Users.RemoveRange(_dbContext.Users);
        _dbContext.SaveChanges();
    }
}
