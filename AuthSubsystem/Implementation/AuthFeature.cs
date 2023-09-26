using Microsoft.IdentityModel.Tokens;
using Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthSubsystem.Implementation
{
    public class AuthFeature : IAuthFeature
    {
        //private string GenerateToken(LoginModel user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {

        //        new Claim(ClaimTypes.Email,user.Email),
        //        new Claim(ClaimTypes.Role,user.Role)
        //    };
        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //        _config["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(15),
        //        signingCredentials: credentials);


        //    return new JwtSecurityTokenHandler().WriteToken(token);

        //}
        public Task Login(LoginModel login_user)
        {
            throw new NotImplementedException();
        }

        public Task Register(RegisterModel register_user)
        {
            throw new NotImplementedException();
        }
    }
}
