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
        Task<CardInfoDto> GetCardByUserIdAsync(int userId);  // Fetch card by user
        Task AddCardAsync(CardInfoDto model);  // Add new card info       
        Task DeleteCardAsync(int userId);  // Remove card info by user
        Task<IEnumerable<CardInfoDto>> GetAllCardInfosByUserIdAsync(int userId);
    }
}
