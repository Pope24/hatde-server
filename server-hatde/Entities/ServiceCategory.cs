namespace server_hatde.Entities
{
    public class ServiceCategory
    {
        public int ServiceCategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<Service>? Services { get; set; }
    }

}
