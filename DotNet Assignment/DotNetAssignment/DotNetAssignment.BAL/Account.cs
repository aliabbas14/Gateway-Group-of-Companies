using DotNetAssignment.BAL.Interface;
using DotNetAssignment.DAL.Interface;
using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.BAL
{
    public class Account : IAccount
    {
        IAccountRepo _acc;
        public Account(IAccountRepo acc)
        {
            _acc = acc;
        }

        /*
            This method is called when user submits the login form after entering email and password. It collects the user data
            and calls the api.
         */

        public object PostLogin(Login model)
        {
           return _acc.PostLogin(model);
        }

        /*
            This method is called when user fills the registration form and submits the form. It collects the user's form data and
            calls the api.
         */

        public void PostRegister(Register model)
        {
            _acc.PostRegister(model);
        }
    }
}
