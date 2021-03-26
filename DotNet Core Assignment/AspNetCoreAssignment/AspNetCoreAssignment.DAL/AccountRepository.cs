using AspNetCoreAssignment.DAL.Interface;
using AspNetCoreAssignment.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCoreAssignment.DAL
{
    public class AccountRepository : IAccountRepository
    {
        public string Login(LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "admin")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("this is my custom Secret key for authnetication.");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, model.Username)
                    }),
                    Expires=DateTime.UtcNow.AddHours(1),
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            else
            {
                return null;
            }
        }
    }
}
