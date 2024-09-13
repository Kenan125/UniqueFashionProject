using Entity.Dtos;
using Entity.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        // POST: api/reviews
        [HttpPost]
        public async Task<IActionResult> SubmitReview([FromBody] ReviewDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var success = await _reviewService.SubmitReviewAsync(model);
                if (!success)
                {
                    return BadRequest("Failed to submit review.");
                }

                return Ok("Review submitted successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/reviews/seller/{sellerId}
        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetReviewsBySeller(Guid sellerId)
        {
            var reviews = await _reviewService.GetReviewsBySellerIdAsync(sellerId);
            if (reviews == null || reviews.Count == 0)
            {
                return NotFound("No reviews found for this seller.");
            }

            return Ok(reviews);
        }

        // GET: api/reviews/user/{userId}/rating
        [HttpGet("user/{userId}/rating")]
        public async Task<IActionResult> GetAverageRatingByUser(Guid userId)
        {
            try
            {
                var averageRating = await _reviewService.GetAverageRatingByUserIdAsync(userId);
                return Ok(new { UserId = userId, AverageRating = averageRating });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
