using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Dto;

namespace Backend.Repositories 
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly UserProfileContext _context;

        public UserProfileRepository(UserProfileContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UserProfileDto?> GetUserByEmailAsync(string email)
        {
            var userProfile = await _context.UserProfiles.FindAsync(email);
            return userProfile?.toDto() ?? null;
        }

        public async Task AddUserAsync(UserProfileDto userProfileDto)
        {
            var userProfile = userProfileDto.toModel();
            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserProfileDto userProfileDto)
        {
            var userProfile = userProfileDto.toModel();
            _context.Entry(userProfile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string email)
        {
            var userProfile = await _context.UserProfiles.FindAsync(email);
            if (userProfile != null)
            {
                _context.UserProfiles.Remove(userProfile);
                await _context.SaveChangesAsync();
            }
        }
    }

    public static class MappingExtensions 
    {

        public static UserProfileDto toDto(this UserProfile model)
        {
            return new UserProfileDto()
            {
                Email = model.Email,
                Name = model.Name,
                ArtistName = model.ArtistName
            };
        }

        public static UserProfile toModel(this UserProfileDto dto)
        {
            return new UserProfile()
            {
                Email = dto.Email,
                Name = dto.Name,
                ArtistName = dto.ArtistName
            };
        }
    }
}