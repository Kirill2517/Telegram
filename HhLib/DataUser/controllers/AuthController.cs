using HhLib.Applicant.model;
using HhLib.DataUser.model;
using HhLib.Share.Controllers.Base;
using HhLib.Share.Models;
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
            if (await bdcontroller.EmailExistsAsync(model.User, model.User.DataUser.email))
                return new { error = "Email already exists." };
            if (!(await bdcontroller.FieldsUniqAsync(model.User.DataUser)))
                return new { error = "Uniq dataUser field already exists." };
            if (!(await bdcontroller.FieldsUniqAsync(model.User)))
                return new { error = "Uniq account field already exists." };
            if (!(await bdcontroller.IndexesExist(model.User)))
                return new { error = "Some values don't exist." };
            if (!(await bdcontroller.IndexesExist(model.User.DataUser)))
                return new { error = "Some values don't exist." };

            await bdcontroller.InsertDataUserAsync(model.User.DataUser, Settings.PasswordHasher.HashPassword(model.password));
            await bdcontroller.InsertUserAsync(model.User, model.User.DataUser.email);
            var type = await bdcontroller.GetAccountType(model.User.DataUser.email);
            return TokenGenerator.GetToken(new SignInModel() { email = model.User.DataUser.email, accountType = type });
        }

        protected override async Task<bool> AuthAsync(SignInModel model)
        {
            model.password = Settings.PasswordHasher.HashPassword(model.password);
            return await bdcontroller.CheckCorrectDataUserAsync(model);
        }

        public async Task<bool> SignUpSecondAccount<T>(string identity, T model) where T : User
        {
            if (!model.IsValid())
                return false;
            if (await bdcontroller.EmailExistsAsync(model, identity))
                return false;
            if (!(await bdcontroller.FieldsUniqAsync(model)))
                return false;

            return await bdcontroller.InsertUserAsync(model, identity);
        }
    }
}
