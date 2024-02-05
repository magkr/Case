using Backend.Repositories;
using Backend.Dto;

namespace Backend.Services 
{
    public interface IUserService
    {
        Task<UserProfileDto?> GetUserByEmail(string email);
        Task AddUser(UserProfileDto userProfileDto);
        Task UpdateUser(UserProfileDto userProfileDto);
        Task DeleteUser(string email);
        Task<bool> DoesEmailExistAsync(string email);
    }

}