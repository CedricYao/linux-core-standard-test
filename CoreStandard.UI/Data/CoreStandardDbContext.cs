using CoreStandard.UI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreStandard.UI.Data
{
    public class CoreStandardDbContext : DbContext
    {
        public CoreStandardDbContext(DbContextOptions<CoreStandardDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
