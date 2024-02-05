using Backend.Repositories;
using Backend.Dto;
using System.Text.RegularExpressions;

namespace Backend.Services 
{
    public class UserService : IUserService
    {
        private readonly IUserProfileRepository _userRepository;

        public UserService(IUserProfileRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<UserProfileDto?> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task AddUser(UserProfileDto userProfileDto)
        {
            if (!IsValidEmailFormat(userProfileDto.Email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            if (await DoesEmailExistAsync(userProfileDto.Email))
            {
                throw new ArgumentException("Email exists!");
            }

            await _userRepository.AddUserAsync(userProfileDto);
        }

        public async Task UpdateUser(UserProfileDto userProfileDto)
        {
            await _userRepository.UpdateUserAsync(userProfileDto);
        }

        public async Task DeleteUser(string email)
        {
            await _userRepository.DeleteUserAsync(email);
        }

        public async Task<bool> DoesEmailExistAsync(string email)
        {
            var userProfile = await GetUserByEmail(email);
            return userProfile != null;
        }

        private bool IsValidEmailFormat(string email)
        {
            var emailRegex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            return emailRegex.IsMatch(email);
        }
    }
}