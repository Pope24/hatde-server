namespace server_hatde.Requests
{
    public class PaymentRequest
    {
        public int BookingId {  get; set; }
        public decimal Amount { get; set; }
        
        public PaymentRequest(int bookingId, decimal amount)
        {
            BookingId = bookingId;
            this.Amount = amount;
        }
    }
}
