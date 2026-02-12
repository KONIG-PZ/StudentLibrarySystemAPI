using Microsoft.EntityFrameworkCore;
using SchoolRecordSystemApi.Models.Entities;

namespace SchoolRecordSystemApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
