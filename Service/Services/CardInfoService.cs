using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CardInfoService : ICardInfoService
    {
        public Task AddCardAsync(CardInfoDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCardAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<CardInfoDto> GetCardByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
