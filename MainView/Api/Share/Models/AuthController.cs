using TelegramLib.Applicant.model;
using TelegramLib.Employer.model;
using TelegramLib.Share.Models;
using TelegramLib.Share.Tokens.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Utils.Controller;
using MySql.Data.MySqlClient;

namespace Telegram.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public AuthController(MySqlConnection mySqlConnection)
        {
            MySqlConnection = mySqlConnection;
        }

        public MySqlConnection MySqlConnection { get; }
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(SignInModel identityUser)
        {
            TelegramLib.DataUser.controllers.AuthController controller = new TelegramLib.DataUser.controllers.AuthController(MySqlConnection);
            return Ok(await controller.AuthorizeAsync(identityUser));
        }

        [HttpPost]
        [Route("signup/applicant")]
        [Route("signup/appl")]
        public async Task<IActionResult> SignUp(SignUpModel<Applicant> model)
        {
            return await SignUpIdentity(model);
        }

        [HttpPost]
        [Route("signup/employer")]
        [Route("signup/empl")]
        public async Task<IActionResult> SignUp(SignUpModel<Employer> model)
        {
            return await SignUpIdentity(model);
        }

        [HttpPost]
        [Route("updatetoken")]
        public async Task<IActionResult> UpdateTokens(RefreshToken refreshToken)
        {
            TelegramLib.DataUser.controllers.AuthController controller = new TelegramLib.DataUser.controllers.AuthController(MySqlConnection);
            return Ok(await controller.UpdateTokens(refreshToken));
        }

        [HttpPost]
        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout(RefreshToken refreshToken)
        {
            TelegramLib.DataUser.controllers.AuthController controller = new TelegramLib.DataUser.controllers.AuthController(MySqlConnection);
            ErrorModel logedout = await controller.Logout(refreshToken, this.GetUserIdentity());
            return Ok(logedout);
        }

        private async Task<IActionResult> SignUpIdentity<T>(SignUpModel<T> model) where T : User
        {
            TelegramLib.DataUser.controllers.AuthController controller = new TelegramLib.DataUser.controllers.AuthController(MySqlConnection);
            if (!this.UserIsAuthorized())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                return Ok(await controller.SignUpUnauthorizedAsync(model));
            }

            return BadRequest();
            //return Ok(await controller.SignUpSecondAccount(this.GetUserIdentity(), model.User));
        }
    }
}
