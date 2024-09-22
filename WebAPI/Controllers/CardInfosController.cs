using AutoMapper;
using Entity.Dtos;
using Entity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CardInfosController : ControllerBase
    {
        private readonly ICardInfoService _cardInfoService;
        private readonly IMapper _mapper;

        public CardInfosController(ICardInfoService cardInfoService, IMapper mapper)
        {
            _cardInfoService = cardInfoService;
            _mapper = mapper;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        

        // GET: api/cardinfo
        [HttpGet]
        public async Task<IActionResult> GetCardInfo()
        {
            int userId = GetUserId();
            var cardInfoDto = await _cardInfoService.GetCardByUserIdAsync(userId);
            if (cardInfoDto == null)
                return NotFound();

            return Ok(cardInfoDto);
        }

        // POST: api/cardinfo
        [HttpPost]
        public async Task<IActionResult> AddCardInfo([FromBody] CardInfoDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int userId = GetUserId();
            model.UserId = userId;

            await _cardInfoService.AddCardAsync(model);

            return Ok();
        }

        // DELETE: api/cardinfo
        [HttpDelete]
        public async Task<IActionResult> DeleteCardInfo()
        {
            int userId = GetUserId();

            await _cardInfoService.DeleteCardAsync(userId);

            return Ok();
        }
    }
}
