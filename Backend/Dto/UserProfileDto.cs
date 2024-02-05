
namespace Backend.Dto 
{
    public class UserProfileDto
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
        public string? ArtistName { get; set; }
    }
}