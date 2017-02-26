using Microsoft.EntityFrameworkCore;
using CastleClashdb.Models.CastleClash;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CastleClashdb.Models;

namespace CastleClashdb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> User { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelbuilder.Entity<AlterHeroes>()
                .HasKey(x => new { x.UserId, x.HeroId });
        }
    }
}
