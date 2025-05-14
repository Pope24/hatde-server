using server_hatde.Entities;

namespace server_hatde.Responses
{
    public class PaymentResponse
    {
        public Booking booking {  get; set; }
        public string? PaymentLink { get; set; }
    }
}
