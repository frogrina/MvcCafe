using Microsoft.EntityFrameworkCore;

namespace MvcCafe.Data
{
    public class MvcCafeContext : DbContext
    {
        public MvcCafeContext(DbContextOptions<MvcCafeContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Cafe> Cafes { get; set; }
        public DbSet<Models.User> Users { get; set; }
    }
}
