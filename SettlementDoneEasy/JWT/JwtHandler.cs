using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SDE_Server.JWT
{
    public class JwtHandler
    {
        private AppSettings Settings;

        public JwtHandler()
        {
            Settings = AppSettings.GetSettings();
        }

        public SigningCredentials GetSigningCredentials()
        {
            byte[] key = Encoding.UTF8.GetBytes(Settings.JwtSettings.securityKey);
            SymmetricSecurityKey secret = new(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public List<Claim> GetClaims(IdentityUser user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: Settings.JwtSettings.validIssuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(Settings.JwtSettings.expiryInMinutes)),
                signingCredentials: signingCredentials);
        }
    }
}
