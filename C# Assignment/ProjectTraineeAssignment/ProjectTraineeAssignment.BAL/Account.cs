using ProjectTraineeAssignment.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTraineeAssignment.Models;
using ProjectTraineeAssignment.DAL.Interface;

namespace ProjectTraineeAssignment.BAL
{
    public class Account : IAccount
    {
        IAccountRepo _acc;
        public Account(IAccountRepo acc)
        {
            _acc = acc;
        }

        /*
         This api is called when user logs in into our system. This api accepts LoginModel which contains email and password as properties and 
         compares the email and password in the database and returns user_id(Primary key) and user name if the credentials are correct.
             */
        public object PostLogin(LoginModel model)
        {
            return _acc.PostLogin(model);
        }


        /*
        This api is called when user fills the registration form and clicks on submit button. This api inserts the user's registration data into
        the database and returns IHttpActionResult.
            */
        public void PostRegister(RegisterModel model)
        {
             _acc.PostRegister(model);
        }
    }
}
