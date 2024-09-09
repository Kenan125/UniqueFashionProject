using Entity.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class CartDto : BaseDto
    {
        public Guid UserId { get; set; }  // Foreign key to the user       
        public UserDto User { get; set; }  // Navigation property
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    }
}
