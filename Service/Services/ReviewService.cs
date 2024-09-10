using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ReviewService : IReviewService
    {
        public Task<double> GetAverageRatingByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReviewDto>> GetReviewsByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SubmitReviewAsync(ReviewDto reviewModel)
        {
            throw new NotImplementedException();
        }
    }
}
