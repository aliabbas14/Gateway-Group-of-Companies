using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetAssignment.BAL.Interface;

namespace DotNetAssignment.Controllers
{
    public class AccountApiController : ApiController
    {
        IAccount _acc;
        public AccountApiController(IAccount acc)
        {
            _acc = acc;
        }

        /*
            This method is called when user fills the registration form and submits the form. It collects the user's form data and
            calls the api.
         */
        public IHttpActionResult PostRegister(Register model)
        {

            _acc.PostRegister(model);
            return Ok();
        }

        /*
            This method is called when user submits the login form after entering email and password. It collects the user data
            and calls the api.
         */
        public IHttpActionResult PostLogin(Login model)
        {
            return Ok(_acc.PostLogin(model));
        }
    }
}
