using server_hatde.Entities;
using server_hatde.Requests;

namespace server_hatde.Services
{
    public interface IPaymentService
    {
        public string CreatePaymentVnPay(PaymentRequest request, HttpContext context);
        public Task<bool> PayByCashAsync(int bookingId, decimal totalAmount);
        public Task<bool> AddPaymentAsync(Payment payment);
        public Task<bool> UpdatePaymentStatusAsync(int paymentId, string status);
    }
}
