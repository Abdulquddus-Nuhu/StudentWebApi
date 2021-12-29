using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi.Data
{
    public class AppDbContext : DbContext
    {
        private readonly DbContextOptions _dco;
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            _dco = options;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}

