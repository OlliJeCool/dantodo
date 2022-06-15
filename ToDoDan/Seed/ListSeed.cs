using ToDoDan.Models;

namespace ToDoDan.Seed
{
    public static class ListSeed
    {
        public static void Seed(ToDoDanDbContext context)
        {
            if (context.Lists.Where(x => x.Name == "MainList" || x.Name == "CompletedList") == null)
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
            else return;
        }
    }
}
