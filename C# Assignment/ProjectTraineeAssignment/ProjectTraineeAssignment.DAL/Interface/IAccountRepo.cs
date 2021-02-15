using ProjectTraineeAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTraineeAssignment.DAL.Interface
{
    public interface IAccountRepo
    {
        /*
        This api is called when user fills the registration form and clicks on submit button. This api inserts the user's registration data into
        the database and returns IHttpActionResult.
            */
        void PostRegister(RegisterModel model);

        /*
         This api is called when user logs in into our system. This api accepts LoginModel which contains email and password as properties and 
         compares the email and password in the database and returns user_id(Primary key) and user name if the credentials are correct.
             */
        Object PostLogin(LoginModel model);
    }
}
