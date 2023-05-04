﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using VroomAuto.AppLogic.Services;

namespace VroomAuto.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserManager<IdentityUser> userIdentity;
        UserService userService;

        public UserController( UserManager<IdentityUser> userIdentity, UserService userService )
        {
            this.userIdentity = userIdentity;
            this.userService = userService;
        }

        public IActionResult Index(  )
        {
            var identityID = userIdentity.GetUserId(User);
            var user = userService.GetUserFromIdentity(identityID);

            return View( user );
        }
    }
}
