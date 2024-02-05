using Backend.Dto;

namespace Backend.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserProfileDto?> GetUserByEmailAsync(string email);
        Task AddUserAsync(UserProfileDto user);
        Task UpdateUserAsync(UserProfileDto user);
        Task DeleteUserAsync(string email);
    }
}
