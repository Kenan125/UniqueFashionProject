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
    public class CardInfoService : ICardInfoService
    {
        private readonly UniqueFashionDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CardInfoService(UniqueFashionDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CardInfoDto>> GetAllCardInfosByUserIdAsync(int userId)
        {
            var cards = await _unitOfWork.GetRepository<CardInfo>().GetAllAsync(ci => ci.UserId == userId);
            return _mapper.Map<IEnumerable<CardInfoDto>>(cards);
        }

        public async Task AddCardAsync(CardInfoDto model)
        {
            var cardInfo = _mapper.Map<CardInfo>(model);
            await _unitOfWork.GetRepository<CardInfo>().AddAsync(cardInfo);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCardAsync(int userId)
        {
            var repository = _unitOfWork.GetRepository<CardInfo>();
            var cardInfo = await repository.GetAsync(ci => ci.UserId == userId);
            if (cardInfo != null)
            {
                await repository.DeleteAsync(cardInfo);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<CardInfoDto> GetCardByUserIdAsync(int userId)
        {
            var cardInfo = await _unitOfWork.GetRepository<CardInfo>().GetAsync(ci => ci.UserId == userId);
            return _mapper.Map<CardInfoDto>(cardInfo);
        }
    }
}
