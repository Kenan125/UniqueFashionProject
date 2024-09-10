using Entity.Dtos;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RoleService : IRoleService
    {
        public Task<bool> AssignRoleToUserAsync(Guid userId, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AssignSellerRoleAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateRoleAsync(RoleDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoleAsync(RoleDto model)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoleDto>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveRoleFromUserAsync(Guid userId, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
