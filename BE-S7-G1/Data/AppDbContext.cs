using BE_S7_G1.Model;
using Microsoft.EntityFrameworkCore;

namespace BE_S7_G1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
