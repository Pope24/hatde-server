using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace server_hatde.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }

        public decimal TotalPrice { get; set; } = 0.0m;
        public string Status { get; set; } = "pending"; //pending, cancel, approved, prepare, completed
        public DateTime EventDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Note { get; set; }
        public User? User { get; set; } = null!;
        public ICollection<BookingDetail>? BookingDetails { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }

}
