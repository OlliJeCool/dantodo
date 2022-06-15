namespace ToDoDan.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Complete { get; set; }

        public Guid ListId { get; set; } = Guid.Empty;
    }
}
