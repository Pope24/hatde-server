using server_hatde.Entities;

namespace server_hatde.Requests
{
    public class BookingRequest
    {
        public List<int> ServiceIds { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime EventDate { get; set; }
        public string? Note { get; set; }
    }
}
