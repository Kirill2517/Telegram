using HhLib.Share.Models;
using HhLib.Static;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Tokens.models
{
    public class AccessToken : Models.Object
    {
        public string access_token { get; set; }
        public DateTime expires { get; set; }
        public string email { get; set; }
        private static ClaimsIdentity GetClaimsIdentity(SignInModel user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.email),
                    new Claim(ClaimTypes.Role, user.accountType.ToString()),
                    new Claim("guid", Guid.NewGuid().ToString())
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        internal static AccessToken GenerateAccessToken(SignInModel user)
        {
            var claimsidentity = GetClaimsIdentity(user);
            var now = DateTime.UtcNow;
            DateTime expires = now.Add(Settings.LIFETIMETS);
            var jwt = new JwtSecurityToken(
            issuer: Settings.ISSUER,
            audience: Settings.AUDIENCE,
            notBefore: now,
            claims: claimsidentity.Claims,
            expires: expires,
            signingCredentials: new SigningCredentials(Settings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AccessToken()
            {
                access_token = encodedJwt,
                email = claimsidentity.Name,
                expires = expires
            };
        }
    }
}
