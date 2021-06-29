using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioFull.CrossCutting.Security
{
    public static class JwtSecurity
    {
        public static string CreateToken(IConfiguration config, int userId)
        {
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));
            SigningCredentials credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim("userId", userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return new JwtSecurityTokenHandler().CreateEncodedJwt(new SecurityTokenDescriptor
            {
                Audience = config["JWT:Audience"],
                Issuer = config["JWT:Issuer"],
                Expires = DateTime.Now.AddMinutes(1440),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials
            });
        }
    }
}
