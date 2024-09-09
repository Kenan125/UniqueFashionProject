using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class ShippingAddressDto : BaseDto
    {
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
