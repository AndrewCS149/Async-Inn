using AsyncInn.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoleInitializer
    {
        // create a list of identity roles
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = AppRoles.Manager, NormalizedName = AppRoles.Manager.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },

             new IdentityRole{Name = AppRoles.Customer, NormalizedName = AppRoles.Customer.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
        };

        // TODO: summary comment
        public static void SeedData(IServiceProvider serviceProvider, UserManager<AppUser> users, IConfiguration _config)
        {
            using (var dbContext = new AsyncInnDbContext(serviceProvider.GetRequiredService<DbContextOptions<AsyncInnDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
                SeedUsers(users, _config);
            }
        }

        // TODO: summary comment
        private static void AddRoles(AsyncInnDbContext context)
        {
            if (context.Roles.Any()) return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        private static void SeedUsers(UserManager<AppUser> userManager, IConfiguration _config)
        {
            if(userManager.FindByEmailAsync(_config["AdminEmail"]).Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = _config["AdminEmail"];
                user.Email = _config["AdminEmail"];
                user.FirstName = "Andrew";
                user.LastName = "Smith";

                IdentityResult result = userManager.CreateAsync(user, _config["AdminPassword"]).Result;

                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, AppRoles.Manager).Wait();
            }
        }
    }
}
