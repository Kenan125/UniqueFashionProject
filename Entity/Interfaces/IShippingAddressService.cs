using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IShippingAddressService
    {
        Task CreateShippingAddressAsync(ShippingAddressDto model);
        Task<ShippingAddressDto> GetShippingAddressByIdAsync(Guid addressId);
        Task UpdateShippingAddressAsync(ShippingAddressDto model);
        Task DeleteShippingAddressAsync(Guid addressId);
    }
}
