using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface ICardInfoService
    {
        Task<CardInfoDto> GetCardByUserIdAsync(Guid userId);  // Fetch card by user
        Task AddCardAsync(CardInfoDto model);  // Add new card info       
        Task DeleteCardAsync(Guid userId);  // Remove card info by user
    }
}
