using HhLib.Static;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HhLib.Share.Models
{
    public static class TokenGenerator
    {
        public static string GetToken(SignInModel user)
        {
            var claimsidentity = GetClaimsIdentity(user);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
            issuer: Settings.ISSUER,
            audience: Settings.AUDIENCE,
            notBefore: now,
            claims: claimsidentity.Claims,
            expires: now.Add(Settings.LIFETIMETS),
            signingCredentials: new SigningCredentials(Settings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                username = claimsidentity.Name
            };

            return JsonConvert.SerializeObject(response);
        }
        private static ClaimsIdentity GetClaimsIdentity(SignInModel user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "user"),
                    new Claim("guid", Guid.NewGuid().ToString())
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
