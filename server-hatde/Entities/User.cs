namespace server_hatde.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = "user"; // "user", "vendor", "admin"
        public string Status { get; set; } = "active"; // "active", "inactive", "banned"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public VendorProfile? VendorProfile { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }

}
