using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IRoleService
    {
        Task<string> CreateRoleAsync(RoleDto model);
        Task DeleteRoleAsync(string id);
        Task<List<RoleDto>> GetAllRolesAsync();
        Task<bool> AssignRoleToUserAsync(string userId, string roleName);
        Task<bool> RemoveRoleFromUserAsync(string userId, string roleName);
        Task<bool> AssignSellerRoleAsync(Guid userId);
    }
}
