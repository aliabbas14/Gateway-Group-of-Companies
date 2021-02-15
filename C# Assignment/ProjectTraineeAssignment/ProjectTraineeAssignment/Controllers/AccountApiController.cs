using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTraineeAssignment.Models;
using System.Security.Cryptography;
using System.Text;
using ProjectTraineeAssignment.BAL.Interface;

namespace ProjectTraineeAssignment.Controllers
{
    public class AccountApiController : ApiController
    {

        IAccount _acc;
        public AccountApiController(IAccount acc)
        {
            _acc = acc;
        }

        /*
         This api is called when user fills the registration form and clicks on submit button. This api inserts the user's registration data into
         the database and returns IHttpActionResult.
             */
        public IHttpActionResult PostRegister(RegisterModel model)
        {
            
            _acc.PostRegister(model);
            return Ok();
        }

        /*
         This api is called when user logs in into our system. This api accepts LoginModel which contains email and password as properties and 
         compares the email and password in the database and returns user_id(Primary key) and user name if the credentials are correct.
             */
        public IHttpActionResult PostLogin(LoginModel model)
        {
            
            return Ok(_acc.PostLogin(model));
        }
    }

}
