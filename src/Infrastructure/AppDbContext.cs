using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts)
            : base(opts)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}