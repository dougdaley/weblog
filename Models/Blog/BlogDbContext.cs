using Microsoft.Data.Entity;

namespace weblog.Models.Blog
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Topic> Topics { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .IsRequired();
                
            modelBuilder.Entity<Topic>()
                .Property(t => t.Title)
                .IsRequired();
        }
    }
}