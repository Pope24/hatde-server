using Microsoft.EntityFrameworkCore;
using server_hatde.Entities;

namespace server_hatde.Services.Impl
{
    public class ReviewService : IReviewService
    {
        private readonly WeddingDbContext _dbContext;

        public ReviewService(WeddingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddReviewAsync(Review review)
        {
            await _dbContext.Reviews.AddAsync(review);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);
            if (review != null)
            {
                _dbContext.Reviews.Remove(review);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _dbContext.Reviews.ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByServiceIdAsync(int id)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.ServiceId == id).ToListAsync();
            return reviews;
        }
    }
}
