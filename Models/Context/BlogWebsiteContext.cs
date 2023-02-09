using Microsoft.EntityFrameworkCore;

namespace BlogWebSite.Models.Context
{
    public class BlogWebsiteContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ANOOBREKHAN; database=BlogWebsiteDb; integrated security=true; TrustServerCertificate=true;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogEntry> BlogEntries { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
