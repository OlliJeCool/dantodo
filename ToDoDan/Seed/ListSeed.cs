using ToDoDan.Models;

namespace ToDoDan.Seed
{
    public static class ListSeed
    {
        public static void Seed(ToDoDanDbContext context)
        {
            context.Lists.Add(new TaskList()
            {
                Id = Guid.NewGuid(),
                Name = "MainList"
            });

            context.Lists.Add(new TaskList()
            {
                Id = Guid.NewGuid(),
                Name = "CompletedList"
            });
            context.SaveChanges();
        }
    }
}
