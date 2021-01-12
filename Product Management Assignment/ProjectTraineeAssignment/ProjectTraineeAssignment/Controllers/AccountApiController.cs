using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTraineeAssignment.Models;
using System.Security.Cryptography;
using System.Text;

namespace ProjectTraineeAssignment.Controllers
{
    public class AccountApiController : ApiController
    {

        /*
         This api is called when user fills the registration form and clicks on submit button. This api inserts the user's registration data into
         the database and returns IHttpActionResult.
             */
        public IHttpActionResult PostRegister(RegisterModel model)
        {
            try {
                SHA512 shaM = new SHA512Managed();
                var hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(model.pwd));

                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var data = new tbl_user()
                    {
                        name = model.name,
                        email = model.email,
                        phone = model.phone,
                        pwd = hash,
                        created_date = DateTime.Now,
                        updated_date = DateTime.Now
                    };

                    context.tbl_user.Add(data);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        /*
         This api is called when user logs in into our system. This api accepts LoginModel which contains email and password as properties and 
         compares the email and password in the database and returns user_id(Primary key) and user name if the credentials are correct.
             */
        public IHttpActionResult PostLogin(LoginModel model)
        {
            try {
                SHA512 shaM = new SHA512Managed();
                var hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(model.pwd));


                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var result = context.tbl_user.Where(x => x.email == model.email && x.pwd == hash).Select(x => new { x.user_id, x.name }).FirstOrDefault();
                    if (result != null)
                        return Ok(result);
                    else
                        return NotFound();
                }
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
    }
    }

}
