using AutoMapper;
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
    public class SellerService : ISellerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SellerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Fetch all sellers
        public async Task<IEnumerable<SellerDto>> GetAllSellersAsync()
        {
            var sellers = await _unitOfWork.GetRepository<Seller>().GetAllAsync();
            return _mapper.Map<IEnumerable<SellerDto>>(sellers);
        }

        // Fetch seller by ID
        public async Task<SellerDto> GetSellerByIdAsync(int sellerId)
        {
            var seller = await _unitOfWork.GetRepository<Seller>().GetByIdAsync(sellerId);
            if (seller == null)
            {
                return null;
            }
            return _mapper.Map<SellerDto>(seller);
        }

        // Create a new seller
        public async Task<bool> CreateSellerAsync(SellerDto model, int userId)
        {
            try
            {
                var seller = new Seller
                {
                    Name = model.Name,
                    UserId = userId,
                };

                await _unitOfWork.GetRepository<Seller>().AddAsync(seller);
                await _unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Fetch seller by UserId
        public async Task<SellerDto> GetSellerByUserIdAsync(int userId)
        {
            var sellers = await _unitOfWork.GetRepository<Seller>().GetAllAsync(s => s.UserId == userId);
            var seller = sellers.FirstOrDefault();
            if (seller == null)
            {
                return null;
            }
            return _mapper.Map<SellerDto>(seller);
        }
    }
}
