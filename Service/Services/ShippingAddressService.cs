using AutoMapper;
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
    public class ShippingAddressService : IShippingAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShippingAddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateShippingAddressAsync(ShippingAddressDto model)
        {
            var address = _mapper.Map<ShippingAddress>(model);
            await _unitOfWork.GetRepository<ShippingAddress>().AddAsync(address);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteShippingAddressAsync(int addressId)
        {
            var repository = _unitOfWork.GetRepository<ShippingAddress>();
            var address = await repository.GetByIdAsync(addressId);
            if (address != null)
            {
                await repository.DeleteAsync(address);
                await _unitOfWork.CommitAsync();
            }
        }
        public async Task<ShippingAddressDto> GetShippingAddressByUserIdAsync(int userId)
        {
            var address = await _unitOfWork.GetRepository<ShippingAddress>().GetAsync(sa => sa.UserId == userId);
            return _mapper.Map<ShippingAddressDto>(address);
        }
        public async Task<ShippingAddressDto> GetShippingAddressByIdAsync(int addressId)
        {
            var address = await _unitOfWork.GetRepository<ShippingAddress>().GetByIdAsync(addressId);
            return _mapper.Map<ShippingAddressDto>(address);
        }

        public async Task UpdateShippingAddressAsync(ShippingAddressDto model)
        {
            var repository = _unitOfWork.GetRepository<ShippingAddress>();
            var address = await repository.GetByIdAsync(model.Id);
            if (address != null)
            {
                _mapper.Map(model, address);
                await repository.UpdateAsync(address);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
