using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SocialNetwork.Configs;
using SocialNetwork.Models.Users;

namespace SocialNetwork.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new FriendConfiguration());
            builder.ApplyConfiguration(new MessageConfuiguration());
        }
    }
    
}
