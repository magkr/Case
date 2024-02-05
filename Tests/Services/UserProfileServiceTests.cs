using Backend.Dto;
using Backend.Repositories;
using Backend.Services;
using Moq;

namespace Services
{
    public class UserProfileServiceTests
    {
        [Fact]
        public async Task GetUserByEmail_ReturnsUser_WhenUserExists()
        {
            var mockRepository = new Mock<IUserProfileRepository>();
            mockRepository
                .Setup(repo => repo.GetUserByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(new UserProfileDto { Email = "test@example.com", Name = "Test" });

            var userService = new UserService(mockRepository.Object);

            var result = await userService.GetUserByEmail("test@example.com");

            Assert.NotNull(result);
            Assert.Equal("test@example.com", result.Email);
        }

        [Fact]
        public async Task AddUser_CreatesUser_WhenUserDoesNotExist()
        {
            var mockRepository = new Mock<IUserProfileRepository>();

            var userService = new UserService(mockRepository.Object);
            var userProfileDto = new UserProfileDto { Email = "test@email.com", Name = "Test" };

            await userService.AddUser(userProfileDto);

            mockRepository.Verify(
                repo => repo.AddUserAsync(It.IsAny<UserProfileDto>()),
                Times.Once
            );
        }

        [Fact]
        public async Task AddUser_SuccessfullyAddsUser_WhenValidEmailFormatAndEmailDoesNotExist()
        {
            var mockRepository = new Mock<IUserProfileRepository>();
            var userService = new UserService(mockRepository.Object);
            var userProfileDto = new UserProfileDto { Email = "test@example.com", Name = "Test" };

            await userService.AddUser(userProfileDto);

            mockRepository.Verify(repo => repo.AddUserAsync(It.IsAny<UserProfileDto>()), Times.Once);
        }

        [Fact]
        public async Task AddUser_ThrowsArgumentException_WhenInvalidEmailFormat()
        {
            var mockRepository = new Mock<IUserProfileRepository>();
            var userService = new UserService(mockRepository.Object);
            var userProfileDto = new UserProfileDto { Email = "invalidemail", Name = "Test" };

            await Assert.ThrowsAsync<ArgumentException>(() => userService.AddUser(userProfileDto));
        }

        [Fact]
        public async Task AddUser_ThrowsArgumentException_WhenEmailExists()
        {
            var mockRepository = new Mock<IUserProfileRepository>();
            mockRepository.Setup(repo => repo.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(new UserProfileDto { Email = "existing@example.com", Name = "Test" });

            var userService = new UserService(mockRepository.Object);
            var userProfileDto = new UserProfileDto { Email = "existing@example.com", Name = "Test" };

            await Assert.ThrowsAsync<ArgumentException>(() => userService.AddUser(userProfileDto));
        }
    }
}
