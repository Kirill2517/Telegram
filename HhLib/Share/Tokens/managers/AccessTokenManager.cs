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
        public AccessToken GetAccessToken(SignInModel model) => AccessToken.GenerateAccessToken(model);
    }
}
