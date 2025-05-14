using Microsoft.EntityFrameworkCore;
using server_hatde.Entities;
using server_hatde.Requests;

namespace server_hatde.Services.Impl
{
    public class BookingService : IBookingService
    {
        private readonly WeddingDbContext _dbContext;

        public BookingService(WeddingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddBookingAsync(BookingRequest request)
        {
            var newBooking = new Booking()
            {
                UserId = request.UserId,
                TotalPrice = request.TotalPrice,
                EventDate = request.EventDate,
                Note = request.Note
            };
            var booking = await _dbContext.Bookings.AddAsync(newBooking);
            await _dbContext.SaveChangesAsync();
            var bookingEntity = booking.Entity;
            if (bookingEntity != null)
            {
                var services = await _dbContext.Services.Where(s => request.ServiceIds.Contains(s.ServiceId)).ToListAsync();
                foreach (var service in services)
                {
                    await _dbContext.BookingDetails.AddAsync(new BookingDetail()
                    {
                        BookingId = bookingEntity.BookingId,
                        ServiceId = service.ServiceId,
                        Price = service.Price,
                        Quantity = 1
                    });
                }
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> ChangeStatusBookingAsync(int bookingId, string status)
        {
            var booking = await _dbContext.Bookings.FirstOrDefaultAsync(b => b.BookingId == bookingId);
            if (booking != null)
            {
                if (booking.Status == "completed")
                {
                    return false;
                }
                if (booking.Status == "prepare" && status == "cancel")
                {
                    return false;
                } else
                {
                    booking.Status = status;
                    _dbContext.Bookings.Update(booking);
                    await _dbContext.SaveChangesAsync();
                }
            }
            return true;
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            return await _dbContext.Bookings.FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _dbContext.Bookings.ToListAsync();
        }
    }
}
