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
        /// <summary>
        /// Create roles
        /// </summary>
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = AppRoles.Manager, NormalizedName = AppRoles.Manager.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },

             new IdentityRole{Name = AppRoles.Customer, NormalizedName = AppRoles.Customer.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
        };

        /// <summary>
        /// Seeds initial data into the database on startup
        /// </summary>
        /// <param name="serviceProvider">IServiceProvider</param>
        /// <param name="users">App user</param>
        /// <param name="_config">IConfiguration</param>
        public static void SeedData(IServiceProvider serviceProvider, UserManager<AppUser> users, IConfiguration _config)
        {
            using (var dbContext = new AsyncInnDbContext(serviceProvider.GetRequiredService<DbContextOptions<AsyncInnDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
                SeedUsers(users, _config);
            }
        }

        /// <summary>
        /// Adds a role to a user
        /// </summary>
        /// <param name="context"></param>
        private static void AddRoles(AsyncInnDbContext context)
        {
            if (context.Roles.Any()) return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Seeds app users into the database on startup
        /// </summary>
        /// <param name="userManager">UserManager with AppUser data type</param>
        /// <param name="_config">IConfiguration</param>
        private static void SeedUsers(UserManager<AppUser> userManager, IConfiguration _config)
        {
            if (userManager.FindByEmailAsync(_config["AdminEmail"]).Result == null)
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