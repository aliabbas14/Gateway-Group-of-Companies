using AspNetCoreAssignment.BAL.Interface;
using AspNetCoreAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        IAccountManager _account;
        public AccountController(IAccountManager account)
        {
            _account = account;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody]LoginModel model)
        {
            string token=_account.Login(model);
            if (token != null)
                return Ok(token);
            else
                return Unauthorized();
        }
    }
}
