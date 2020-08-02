using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AsyncInn.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _config = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // POST: api/Account/register
        [HttpPost]
        [Authorize(Policy = "TierTwo")]
        [Route("register")]
        public async Task<IActionResult> RegisterTierOne(RegisterDTO register)
        {
            // instantiate new user
            AppUser user = new AppUser()
            {
                Email = register.Email,
                UserName = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName
            };

            // get current user's role
            var currentUser = User.FindFirstValue(ClaimTypes.Role);

            var result = await _userManager.CreateAsync(user, register.Password);

            // if current users role is a district manager
            if (currentUser.ToLower() == "districtmanager")
            {
                if (result.Succeeded)
                {
                    if (register.Role.ToLower() == "districtmanager")
                    {
                        await _userManager.AddToRoleAsync(user, AppRoles.DistrictManager);
                    }
                    else if (register.Role.ToLower() == "propertymanager")
                    {
                        await _userManager.AddToRoleAsync(user, AppRoles.PropertyManager);
                    }
                    else if (register.Role.ToLower() == "agent")
                    {
                        await _userManager.AddToRoleAsync(user, AppRoles.Agent);
                    }
                    else
                    {
                        return BadRequest("Invalid Registration");
                    }

                    await _signInManager.SignInAsync(user, false);
                    return Ok();
                }
            }
            // if current user's role is a property manager
            else if (currentUser.ToLower() == "propertymanager")
            {
                if (result.Succeeded)
                {
                    if (register.Role.ToLower() == "agent")
                    {
                        await _userManager.AddToRoleAsync(user, AppRoles.Agent);
                    }
                    else
                    {
                        return BadRequest("Rights not granted");
                    }

                    await _signInManager.SignInAsync(user, false);
                    return Ok();
                }
            }

            return BadRequest("Invalid Registration");
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

            if (result.Succeeded)
            {
                // look the user up
                AppUser user = await _userManager.FindByEmailAsync(login.Email);

                // find the users role
                var identityRole = await _userManager.GetRolesAsync(user);
                var token = CreateToken(user, identityRole.ToList());

                return Ok(new
                {
                    jwt = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return BadRequest("Username or password incorrect");
        }

        [HttpPost]
        [Authorize(Policy = "TierOne")]
        [Route("assign/role")]
        public async Task AssignRoleToUser(AssignRoleDTO assignment)
        {
            var user = await _userManager.FindByEmailAsync(assignment.Email);
            await _userManager.AddToRoleAsync(user, assignment.Role);
        }

        private JwtSecurityToken CreateToken(AppUser user, List<string> role)
        {
            // Token requires pieces of info called "claims"
            // Person/User is the principle
            // a principle can have many forms of identity
            // an identity contains many claims
            // a claim is a statement about the user "I have brown hair"

            var authClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("UserId", user.Id)
            };

            foreach (var item in role)
                authClaims.Add(new Claim(ClaimTypes.Role, item));

            var token = AuthenticateToken(authClaims);

            return token;
        }

        private JwtSecurityToken AuthenticateToken(List<Claim> claims)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTKey"]));

            var token = new JwtSecurityToken(
                issuer: _config["JWTIssuer"],
                audience: _config["JWTIssuer"],
                expires: DateTime.UtcNow.AddHours(24),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}