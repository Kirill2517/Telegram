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

namespace Telegram.Api
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(SignInModel identityUser)
        {
            var controller = new HhLib.DataUser.controllers.AuthController();
            return Ok(await controller.AuthorizeAsync(identityUser));
        }

        [HttpPost]
        [Route("phone")]
        public async Task<IActionResult> GetPhone()
        {
            AuthManager applicantModelController = new AuthManager(this.GetUserIdentity());
            return Ok(await applicantModelController.GetGuidAsync());
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("signup/applicant")]
        [Route("signup/appl")]
        public async Task<IActionResult> SignUp(SignUpModel<Applicant> model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var controller = new HhLib.DataUser.controllers.AuthController();

            return Ok(await controller.SignUpAsync(model));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signup/employer")]
        [Route("signup/empl")]
        public async Task<IActionResult> SignUp(SignUpModel<Employer> model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var controller = new HhLib.DataUser.controllers.AuthController();

            return Ok(await controller.SignUpAsync(model));
        }
    }
}
