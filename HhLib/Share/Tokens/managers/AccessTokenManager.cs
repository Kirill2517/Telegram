using HhLib.Share.models;
using HhLib.Share.Models;
using HhLib.Share.Tokens.managers;
using HhLib.Share.Tokens.models;
using HhLib.Static;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Tokens.managers
{
    class AccessTokenManager : DataBaseController
    {
        #region oldcode
        //public static async Task<object> GetToken(SignInModel user)
        //{
        //    var refreshtokenmanager = new RefreshTokenManager();
        //    var refresh = await refreshtokenmanager.CreateNewSession(user.email, user.fingerprint);
        //    if (refresh.GetType() != typeof(string))
        //        return refresh;
        //    return CollectTokens(user, refresh as string);
        //}

        //private static object CollectTokens(SignInModel user, string refresh)
        //{
        //    var claimsidentity = GetClaimsIdentity(user);
        //    var now = DateTime.UtcNow;
        //    DateTime expires = now.Add(Settings.LIFETIMETS);
        //    var jwt = new JwtSecurityToken(
        //    issuer: Settings.ISSUER,
        //    audience: Settings.AUDIENCE,
        //    notBefore: now,
        //    claims: claimsidentity.Claims,
        //    expires: expires,
        //    signingCredentials: new SigningCredentials(Settings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //    var response = new
        //    {
        //        access_token = encodedJwt,
        //        username = claimsidentity.Name,
        //        expires,
        //        refresh
        //    };

        //    return response;
        //}

        //public static async Task<object> GetToken(SignInModel user, string refresh)
        //{
        //    return CollectTokens(user, refresh);
        //}

        //private static ClaimsIdentity GetClaimsIdentity(SignInModel user)
        //{
        //    var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, user.email),
        //            new Claim(ClaimTypes.Role, user.accountType.ToString()),
        //            new Claim("guid", Guid.NewGuid().ToString())
        //        };
        //    ClaimsIdentity claimsIdentity =
        //    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
        //        ClaimsIdentity.DefaultRoleClaimType);
        //    return claimsIdentity;
        //} 
        #endregion

        public AccessToken GetAccessToken(SignInModel model) => AccessToken.GenerateAccessToken(model);
    }
}
