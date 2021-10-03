using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SDE_Server.Domain.Entities;
using SDE_Server.Domain.Repositories;
using SDE_Server.JWT;
using SDE_Server.Models;
using SDE_Server.Models.Auth;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SDE_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        private JwtHandler _jwtHandler;
        private UserRepository _userRepository;

        public AuthController(UserManager<IdentityUser> userManager, JwtHandler jwtHandler, UserRepository userRepository)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        public async Task<LoginReponseModel> Login([FromBody] LoginModel loginModel)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                return new LoginReponseModel
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Invalid Authentication"
                };
            }

            UserModel rtnUser = await _userRepository.GetUserByEmail(user.Email);

            SigningCredentials signingCredentials = _jwtHandler.GetSigningCredentials();
            List<Claim> claims = _jwtHandler.GetClaims(user);
            JwtSecurityToken tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new LoginReponseModel
            {
                IsAuthSuccessful = true,
                Token = token,
                User = rtnUser
            };
        }
    }
}
