using Feed.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace Feed.API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<FeedEntity> Feed { get; set; }
    }
}
