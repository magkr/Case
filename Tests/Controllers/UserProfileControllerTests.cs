using Backend.Controllers;
using Backend.Dto;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Controllers
{
    public class UserProfileControllerTests
    {
        [Fact]
        public async Task GetUserByEmail_ReturnsNotFound_WhenUserDoesNotExist()
        {
            var mockService = new Mock<IUserService>();
            mockService.Setup(service => service.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync((UserProfileDto)null);

            var controller = new UserProfileController(mockService.Object);

            var result = await controller.GetUserByEmail("nonexistent@example.com");

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task AddUser_ReturnsCreatedAtAction_WhenUserCreatedSuccessfully()
        {
            var mockService = new Mock<IUserService>();
            mockService.Setup(service => service.AddUser(It.IsAny<UserProfileDto>())).Verifiable();
            
            var controller = new UserProfileController(mockService.Object);
            var userProfileDto = new UserProfileDto { Email = "test@email.com", Name = "Test" };

            var result = await controller.AddUser(userProfileDto);

            Assert.IsType<CreatedAtActionResult>(result);
            mockService.Verify(); 
        }

        [Fact]
        public async Task AddUser_ReturnsBadRequest_WhenUserWithDuplicateEmail()
        {
            var mockService = new Mock<IUserService>();
            mockService.Setup(service => service.AddUser(It.IsAny<UserProfileDto>()))
                    .ThrowsAsync(new ArgumentException("Email already exists"));

            var controller = new UserProfileController(mockService.Object);
            var userProfileDto = new UserProfileDto { Email = "test@email.com", Name = "Test" };

            var result = await controller.AddUser(userProfileDto);

            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
        }
    }
}
