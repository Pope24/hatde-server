using server_hatde.Entities;
using server_hatde.Requests;

namespace server_hatde.Services
{
    public interface IBookingService
    {
        Task<bool> AddBookingAsync(BookingRequest request);
        Task<bool> ChangeStatusBookingAsync(int bookingId, string status);
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int bookingId);
    }
}
