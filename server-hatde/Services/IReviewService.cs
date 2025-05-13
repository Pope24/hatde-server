using server_hatde.Entities;

namespace server_hatde.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetReviewsByServiceIdAsync(int id);
        Task<bool> AddReviewAsync(Review review);
        Task DeleteReviewAsync(int id);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
    }
}
