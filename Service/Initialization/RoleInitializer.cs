using Entity.Identities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Initialization
{
    public class RoleInitializer
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleInitializer(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var role = new AppRole { Name = "Admin" };
                await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var role = new AppRole { Name = "User" };
                await _roleManager.CreateAsync(role);
            }
            if (!await _roleManager.RoleExistsAsync("Seller"))
            {
                var role = new AppRole { Name = "Seller"};
                await _roleManager.CreateAsync(role);
            }
        }
    }
}
