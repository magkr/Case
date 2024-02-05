using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class UserProfile
    {
        [Key]
        public required string Email { get; set; }
        public required string Name { get; set; }
        public string? ArtistName { get; set; }
    }
}
