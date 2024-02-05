using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class UserProfileContext(DbContextOptions<UserProfileContext> options) : DbContext(options)
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
