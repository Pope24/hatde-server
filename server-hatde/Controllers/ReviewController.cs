using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_hatde.Entities;
using server_hatde.Services;

namespace server_hatde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }
        [HttpGet]
        public async Task<IActionResult> GetReviewsAsync()
        {
            var reviews = await reviewService.GetAllReviewsAsync();
            if (reviews.Count() == 0)
            {
                return NotFound();
            }
            return Ok(reviews);
        }
        [HttpGet("{idService}")]
        public async Task<IActionResult> GetReviewsByServiceIdAsync(int idService)
        {
            var reviews = await reviewService.GetReviewsByServiceIdAsync(idService);
            if (reviews.Count() == 0)
            {
                return NotFound();
            }
            return Ok(reviews);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddReviewAsync([FromBody] Review review)
        {
            await reviewService.AddReviewAsync(review);
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteReviewAsync(int id)
        {
            await reviewService.DeleteReviewAsync(id);
            return Ok();
        }
    }
}
