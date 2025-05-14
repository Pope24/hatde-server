namespace server_hatde.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public string PaymentMethod { get; set; } = "cash"; // "paypal", "vnpay", "cash"
        public string PaymentStatus { get; set; } = "pending"; // "paid", "failed", "unpaid", etc.
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public Booking? Booking { get; set; } = null!;
    }

}
