using Microsoft.EntityFrameworkCore;
using StudentLibrarySystem.Models.Entities;

namespace StudentLibrarySystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Students> Students { get; set; }
    }
}
