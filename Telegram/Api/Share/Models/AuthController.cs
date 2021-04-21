using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Utils.Controller;
using HhLib.Share.Models;
using HhLib.DataUser.controllers;
using HhLib.Applicant.model;
using HhLib.Applicant.Managers;
using Newtonsoft.Json.Serialization;
using HhLib.Employer.model;
using HhLib.Share.Tokens.models;

namespace Telegram.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(SignInModel identityUser)
        {
            var controller = new HhLib.DataUser.controllers.AuthController();
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
            var controller = new HhLib.DataUser.controllers.AuthController();
            return Ok(await controller.UpdateTokens(refreshToken));
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout(RefreshToken refreshToken)
        {
            var controller = new HhLib.DataUser.controllers.AuthController();
            var logedout = await controller.Logout(refreshToken, this.GetUserIdentity());
            return Ok(logedout);
        }

        private async Task<IActionResult> SignUpIdentity<T>(SignUpModel<T> model) where T : User
        {
            var controller = new HhLib.DataUser.controllers.AuthController();
            if (!this.UserIsAuthorized())
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                return Ok(await controller.SignUpUnauthorizedAsync(model));
            }

            return BadRequest();
            //return Ok(await controller.SignUpSecondAccount(this.GetUserIdentity(), model.User));
        }
    }
}
