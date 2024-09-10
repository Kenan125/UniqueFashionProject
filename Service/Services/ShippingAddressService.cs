using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ShippingAddressService : IShippingAddressService
    {
        public Task CreateShippingAddressAsync(ShippingAddressDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteShippingAddressAsync(Guid addressId)
        {
            throw new NotImplementedException();
        }

        public Task<ShippingAddressDto> GetShippingAddressByIdAsync(Guid addressId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateShippingAddressAsync(ShippingAddressDto model)
        {
            throw new NotImplementedException();
        }
    }
}
