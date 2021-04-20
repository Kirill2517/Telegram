using HhLib.Applicant.model;
using HhLib.DataUser.model;
using HhLib.Share.Controllers.Base;
using HhLib.Share.Models;
using HhLib.Share.RefreshToken.managers;
using HhLib.Share.Utils.Extensions;
using HhLib.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.DataUser.controllers
{
    public class AuthController : AuthControllerBase
    {

        public override async Task<object> SignUpUnauthorizedAsync<T>(SignUpModel<T> model)
        {
            if (!await model.ValidPassword())
                return new { errors = model.Errors };
            if (!model.IsValid())
                return new { error = "Model is not valid." };
            if (await EmailExistsAsync(model.User, model.User.DataUser.email))
                return new { error = "Email already exists." };
            if (!(await FieldsUniqAsync(model.User.DataUser)))
                return new { error = "Uniq dataUser field already exists." };
            if (!(await FieldsUniqAsync(model.User)))
                return new { error = "Uniq account field already exists." };
            if (!(await IndexesExist(model.User)))
                return new { error = "Some values don't exist." };
            if (!(await IndexesExist(model.User.DataUser)))
                return new { error = "Some values don't exist." };

            await InsertDataUserAsync(model.User.DataUser, Settings.Hasher.HashPassword(model.password));
            await InsertUserAsync(model.User, model.User.DataUser.email);
            var type = await GetAccountType(model.User.DataUser.email);
            object token = await TokenGenerator.GetToken(new SignInModel() { email = model.User.DataUser.email, accountType = type, fingerprint = model.fingerprint });
            return token;
        }

        protected override async Task<bool> AuthAsync(SignInModel model)
        {
//#if RELEASE
            model.password = Settings.Hasher.HashPassword(model.password); 
//#endif
            return await CheckCorrectDataUserAsync(model);
        }

        public async Task Logout(string fingerprint, string refreshToken, string email)
        {
            //var refreshtokenmanager = new RefreshTokenManager();
            //await refreshtokenmanager.DeleteSession(fingerprint, refreshToken);
        }

        public async Task<object> UpdateTokens(string fingerprint, string refreshtoken)
        {
            var refreshtokenmanager = new RefreshTokenManager();
            var rtDB = await refreshtokenmanager.UpdateRefreshToken(fingerprint, refreshtoken);
            if (rtDB.GetType() != typeof(string))
                return rtDB;

            var sql = $"{Settings.SqlFolder}/refreshSessions/GetEmailByFingerprint.sql".ReadStringFromatFromFile(fingerprint);
            var email = await QueryCommandSingleAsync<string>(sql);
            var type = await GetAccountType(email);
            return await TokenGenerator.GetToken(new SignInModel() { email = email, accountType = type, fingerprint = fingerprint }, rtDB as string);
        }

        public async Task<bool> SignUpSecondAccount<T>(string identity, T model) where T : User
        {
            if (!model.IsValid())
                return false;
            if (await EmailExistsAsync(model, identity))
                return false;
            if (!(await FieldsUniqAsync(model)))
                return false;

            return await InsertUserAsync(model, identity);
        }
    }
}
