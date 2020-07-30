using AsyncInn.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class UserRepo
    {
        private AsyncInnDbContext _context;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public UserRepo(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AsyncInnDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //public async bool ValidateUser(List<Claim> claims)
        //{
        //    // get the name claim
        //    var nameClaim = claims.FirstOrDefault(x => x.Type == "FirstName").Value;
        //    if(nameClaim == "Andrew")
        //    {
        //        // do something cool
        //    }

        //    return true;
        //}
    }
}
