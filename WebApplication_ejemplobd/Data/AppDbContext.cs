using Microsoft.EntityFrameworkCore;
using WebApplication_ejemplobd.Models;
namespace WebApplication_ejemplobd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
