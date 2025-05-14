using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_hatde.Requests;
using server_hatde.Responses;
using server_hatde.Services;

namespace server_hatde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IBookingService _bookingService;

        public PaymentController(IPaymentService paymentService, IBookingService bookingService)
        {
            _paymentService = paymentService;
            _bookingService = bookingService;
        }

        [HttpGet("vnpay")]
        public async Task<PaymentResponse> CreatePaymentVNPayForBookingAsync(int bookingId, decimal totalAmount)
        {
            var booking = await _bookingService.GetBookingByIdAsync(bookingId);
            var paymentLink = _paymentService.CreatePaymentVnPay(
                new PaymentRequest(bookingId, totalAmount), HttpContext);
            return new PaymentResponse()
            {
                booking = booking,
                PaymentLink = paymentLink
            };
        }
        [HttpGet("cash")]
        public async Task<IActionResult> PayByCashAsync(int bookingId, decimal totalAmount)
        {
            var booking = await _bookingService.GetBookingByIdAsync(bookingId);
            await _paymentService.PayByCashAsync(bookingId, totalAmount);
            return Ok();
        }
        [HttpPost("change-status")]
        public async Task<IActionResult> ChangeStatusPaymentAsync(int paymentId, string status)
        {
            await _paymentService.UpdatePaymentStatusAsync(paymentId, status);
            return Ok();
        }
    }
}
