﻿using apiProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace apiProject.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]

        public IHttpActionResult Register(AccountModel model)
        {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbcontext());
                var manager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 3
                };
                IdentityResult result = manager.Create(user, model.Password);
            try
            {
                manager.AddToRoles(user.Id, model.Roles);
                return Ok(result);

            }
            catch {
                return Ok(result);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("api/GetUserClaims")]

        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return model;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("api/ForAdminRole")]
        public string ForAdminRole()
        {
            return "for admin role";
        }

        [HttpGet]
        [Authorize(Roles = "customer")]
        [Route("api/ForAuthorRole")]
        public string ForAuthorRole()
        {
            return "For author role";
        }
    }
}
