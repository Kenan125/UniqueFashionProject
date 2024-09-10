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
        Task<List<ReviewDto>> GetReviewsByUserIdAsync(Guid userId);
        Task<bool> SubmitReviewAsync(ReviewDto reviewModel);
        Task<double> GetAverageRatingByUserIdAsync(Guid userId);
    }
}
