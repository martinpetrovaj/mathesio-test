using Microsoft.EntityFrameworkCore;

namespace Mathesio.Discussion.DAL
{
    public class DiscussionContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MathesioDiscussion;Initial Catalog=DiscussionDB;");
        }
    }
}
