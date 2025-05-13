namespace server_hatde.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int VendorId { get; set; }
        public int ServiceCategoryId { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? MainColor { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = "pending"; //pending, accepted
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public VendorProfile? Vendor { get; set; } = null!;
        public ServiceCategory? Category { get; set; } = null!;

        public string ImageDemo { get; set; }
        public ICollection<BookingDetail>? BookingDetails { get; set; }
    }

}
