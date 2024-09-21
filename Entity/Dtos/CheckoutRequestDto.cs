using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class CheckoutRequestDto
    {
        public List<CartItemDto> CartItems { get; set; }
        public CardInfoDto CardInfo { get; set; }
        public ShippingAddressDto ShippingAddress { get; set; }
    }
}
