﻿using apiProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiProject.Controllers
{
    public class RolesController : ApiController
    {
        [HttpGet]
        [Route("api/GetAllRoles")]
        [AllowAnonymous]
        public HttpResponseMessage GetRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbcontext());
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMngr.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();
            return this.Request.CreateResponse(HttpStatusCode.OK, roles);
        }
    }
}
