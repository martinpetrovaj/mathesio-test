using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mathesio.Discussion.DAL
{
    public class DiscussionContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Author> Authors { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DiscussionContext(IConfiguration configuration) : base()
        {
            _connectionString = configuration.GetConnectionString("DiscussionDB");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
