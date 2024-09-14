using AutoMapper;
using DataAccess.Contexts;
using Entity.Dtos;
using Entity.Entities;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UniqueFashionDbContext _context;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper, UniqueFashionDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public async Task<double> GetAverageRatingByUserIdAsync(int userId)
        {
            var reviews = await _unitOfWork.GetRepository<Review>().GetAllAsync(r => r.UserId == userId);
            if (reviews==null || !reviews.Any())
            {
                return 0; // No reviews available
            }

            return reviews.Average(r  => r.Rating ?? default(double));
        }


        public async Task<List<ReviewDto>> GetReviewsBySellerIdAsync(int sellerId)
        {
            var reviews = await _unitOfWork.GetRepository<Review>()
                                           .GetAllAsync(r => r.SellerId == sellerId);

            foreach (var review in reviews)
            {
                _context.Entry(review).Reference(r => r.User).Load();
            }

            return _mapper.Map<List<ReviewDto>>(reviews);
        }

        public async Task<bool> SubmitReviewAsync(ReviewDto reviewModel)
        {
            if (reviewModel.Rating <= 0)
            {
                throw new InvalidOperationException("A star rating is required to submit a review.");
            }


            var review = _mapper.Map<Review>(reviewModel);


            review.CreatedDate = DateTime.UtcNow;


            await _unitOfWork.GetRepository<Review>().AddAsync(review);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
