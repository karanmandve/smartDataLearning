using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace TrainningSessionExamples
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        Dictionary<string, string> UsersRecords = new Dictionary<string, string>
    {
        { "user1","password1"},
        { "user2","password2"},
        { "user3","password3"},
    };

        private readonly IConfiguration iconfiguration;
        public JWTManagerRepository(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        public Tokens Authenticate(Login users)
        {
            if (!UsersRecords.Any(x => x.Key == users.Name && x.Value == users.Password))
            {
                return null;
            }

            var claims = GetClaims(users);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"], audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                claims: claims, //new List<Claim>(), 
                expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
            //  var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

      //      var token = new JwtSecurityToken(
      //    _options.Issuer,
      //    _options.Audience,
      //    claims,
      //    expires: expires,
      //    signingCredentials: creds
      //);
            var tokenHandler = new JwtSecurityTokenHandler();
            return new Tokens { Token = tokenHandler.WriteToken(tokeOptions) };

        }

        public  List<Claim> GetClaims(Login users)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, users.Name.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
            };
        }
    }
}
