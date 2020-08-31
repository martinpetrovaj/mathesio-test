using Microsoft.EntityFrameworkCore;

namespace Mathesio.Discussion.DAL
{
    public class DiscussionContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DiscussionContext(DbContextOptions<DiscussionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: mark Name as unique in Author.cs once EF Core adds support
            modelBuilder.Entity<Author>()
                .HasIndex(a => new { a.Name })
                .IsUnique(true);
        }
    }
}
