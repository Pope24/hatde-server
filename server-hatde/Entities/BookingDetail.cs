namespace server_hatde.Entities
{
    public class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public int BookingId { get; set; }
        public int ServiceId { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;

        public Booking Booking { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }

}
