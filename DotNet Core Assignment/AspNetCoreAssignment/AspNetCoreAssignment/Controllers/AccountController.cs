﻿using AspNetCoreAssignment.BAL.Interface;
using AspNetCoreAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        ILogger _logger;
        IAccountManager _account;
        public AccountController(IAccountManager account,ILogger<AccountController> logger)
        {
            _account = account;
            _logger = logger;
        }


        //<summary>
        //    This api accepts user's username and password and passes it to other layers and check wether the credentails are valid or not.
        //    If credentails are valid it returns a JWT Token otherwise not.
        //</summary>
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody]LoginModel model)
        {
            try {
                string token = _account.Login(model);
                if (token != null)
                    return Ok(token);
                else
                    return Unauthorized();
            }
            catch(Exception e) {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
