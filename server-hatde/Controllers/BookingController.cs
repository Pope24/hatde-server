using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_hatde.Requests;
using server_hatde.Services;

namespace server_hatde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBookingAsync([FromBody] BookingRequest request)
        {
            await _bookingService.AddBookingAsync(request);
            return Ok();
        }
        [HttpPost("change-status/{id}")]
        public async Task<IActionResult> ChangeStatusBookingAsync(int id, [FromBody] string status)
        {
            var isChanged = await _bookingService.ChangeStatusBookingAsync(id, status);
            if (isChanged)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetBookingsAsync()
        {
            var bookings = await _bookingService.GetBookingsAsync();
            if (bookings.Count() == 0)
            {
                return NoContent();
            }
            return Ok(bookings);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }
    }
}
