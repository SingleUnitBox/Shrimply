using Microsoft.EntityFrameworkCore;
using Shrimply.Models.Domain;

namespace Shrimply.Data
{
    public class ShrimplyDbContext : DbContext
    {
        public ShrimplyDbContext(DbContextOptions<ShrimplyDbContext> options) : base(options)
        {
        }
        public DbSet<Shrimp> Shrimps { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Like> Like { get; set; }
    }
}
