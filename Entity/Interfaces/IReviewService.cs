using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IReviewService
    {
        Task<List<ReviewDto>> GetReviewsBySellerIdAsync(int sellerId);
        Task<bool> SubmitReviewAsync(ReviewDto reviewModel);
        Task<double> GetAverageRatingByUserIdAsync(int userId);
    }
}
