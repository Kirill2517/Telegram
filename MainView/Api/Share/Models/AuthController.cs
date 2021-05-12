using TelegramLib.Applicant.model;
using TelegramLib.Employer.model;
using TelegramLib.Share.Models;
using TelegramLib.Share.Tokens.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Utils.Controller;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Telegram.Api.Share.Models;

namespace Telegram.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBaseModel
    {
        public AuthController(MySqlConnection connection) : base(connection)
        {
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(SignInModel identityUser)
        {
            TelegramLib.DataUser.controllers.AuthController controller = new(Connection);
            return Ok(await controller.AuthorizeAsync(identityUser));
        }

        [HttpPost]
        [Route("signup/applicant")]
        public async Task<IActionResult> SignUp(SignUpModel<Applicant> model)
        {
            return await DiagnosticStopWatch(() => SignUpIdentity(model));
        }

        [HttpPost]
        [Route("signup/employer")]
        public async Task<IActionResult> SignUp(SignUpModel<Employer> model)
        {

            return await DiagnosticStopWatch(() => SignUpIdentity(model));
        }

        [HttpPost]
        [Route("updatetoken")]
        public async Task<IActionResult> UpdateTokens(RefreshToken refreshToken)
        {
            TelegramLib.DataUser.controllers.AuthController controller = new(Connection);
            return Ok(await controller.UpdateTokens(refreshToken));
        }

        [HttpPost]
        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout(RefreshToken refreshToken)
        {
            TelegramLib.DataUser.controllers.AuthController controller = new(Connection);
            ErrorModel logedout = await controller.Logout(refreshToken, this.GetUserIdentity());
            return Ok(logedout);
        }

        private async Task<IActionResult> SignUpIdentity<T>(SignUpModel<T> model) where T : User
        {
            TelegramLib.DataUser.controllers.AuthController controller = new(Connection);
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
