using TelegramLib.Share.Models;
using TelegramLib.Static;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TelegramLib.Share.Tokens.models
{
    public class AccessToken : Models.Object
    {
        public string access_token { get; set; }
        public DateTime expires { get; set; }
        public string email { get; set; }
        private static ClaimsIdentity GetClaimsIdentity(SignInModel user)
        {
            List<Claim> claims = new List<Claim>
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
            //оставить только guid
            //все остальное записать в бд
            ClaimsIdentity claimsidentity = GetClaimsIdentity(user);
            DateTime now = DateTime.UtcNow;
            DateTime expires = now.Add(Settings.LIFETIMETS);
            JwtSecurityToken jwt = new(
            issuer: Settings.ISSUER,
            audience: Settings.AUDIENCE,
            notBefore: now,
            claims: claimsidentity.Claims,
            expires: expires,
            signingCredentials: new SigningCredentials(Settings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AccessToken()
            {
                access_token = encodedJwt,
                email = claimsidentity.Name,
                expires = expires
            };
        }
    }
}
