using System;
using System.Threading.Tasks;
using WebScraperApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.WebSockets.Internal;

namespace WebScraperApp
{
    public static class SeedData
    {
        public static async Task InitializeAsync(
        IServiceProvider services)
        {
            var roleManager = services
            .GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);
            var userManager = services
            .GetRequiredService<UserManager<IdentityUser>>(
            );
            await EnsureTestAdminAsync(userManager);
        }
        private static async Task EnsureRolesAsync(
        RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager
            .RoleExistsAsync(Constants.AdministratorRole);
            if (alreadyExists) return;
            await roleManager.CreateAsync(
            new IdentityRole(Constants.AdministratorRole));
        }    
    }
}        