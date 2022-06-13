using Microsoft.EntityFrameworkCore;

namespace ToDoDan.Models
{
    public class ToDoDanDbContext : DbContext
    {
        public ToDoDanDbContext(DbContextOptions<ToDoDanDbContext> options)
            : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<List> Lists { get; set; }
    }
}
