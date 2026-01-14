using Microsoft.EntityFrameworkCore;
using StudentLibrarySystem.Models;

namespace StudentLibrarySystem.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Students> StudentInfo { get; set; }
        public ApiContext(DbContextOptions<ApiContext>options)
            :base(options)
        {

        }
        

    }
}
