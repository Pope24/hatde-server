namespace server_hatde.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }

        public int Rating { get; set; } // 1 - 5
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Booking? Booking { get; set; } = null!;
        public User? User { get; set; } = null!;
        public Service? Service { get; set; } = null!;
    }

}
