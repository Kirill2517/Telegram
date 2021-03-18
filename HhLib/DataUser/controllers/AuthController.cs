using HhLib.Applicant.model;
using HhLib.DataUser.model;
using HhLib.Share.Controllers.Base;
using HhLib.Share.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.DataUser.controllers
{
    public class AuthController : AuthControllerBase
    {
        AuthDataBaseController bdcontroller = new AuthDataBaseController();
        public override async Task<string> SignUpUnauthorizedAsync<T>(SignUpModel<T> model)
        {
            if (!model.IsValid())
                return JsonConvert.SerializeObject(new { error = "Model is not valid." });
            if (await bdcontroller.EmailExistsAsync(model.User, model.User.DataUser.email))
                return JsonConvert.SerializeObject(new { error = "Email already exists." });
            if (!(await bdcontroller.FieldsUniqAsync(model.User.DataUser)))
                return JsonConvert.SerializeObject(new { error = "Uniq dataUser field already exists." });
            if (!(await bdcontroller.FieldsUniqAsync(model.User)))
                return JsonConvert.SerializeObject(new { error = "Uniq account field already exists." });

            await bdcontroller.InsertDataUserAsync(model.User.DataUser, model.password);
            await bdcontroller.InsertUserAsync(model.User, model.User.DataUser.email);

            return TokenGenerator.GetToken(new SignInModel() { email = model.User.DataUser.email, password = model.password });
        }

        protected override async Task<bool> AuthAsync(SignInModel model)
        {
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
