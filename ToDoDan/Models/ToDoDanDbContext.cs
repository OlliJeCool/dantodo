using Microsoft.EntityFrameworkCore;

namespace ToDoDan.Models
{
    public class ToDoDanDbContext : DbContext
    {
        public ToDoDanDbContext(DbContextOptions<ToDoDanDbContext> options)
            : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<TaskList> Lists { get; set; }
    }
}
