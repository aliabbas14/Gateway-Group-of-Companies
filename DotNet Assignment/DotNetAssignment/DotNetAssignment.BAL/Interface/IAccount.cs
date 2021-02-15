using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.BAL.Interface
{
    public interface IAccount
    {

        /*
            This method is called when user fills the registration form and submits the form. It collects the user's form data and
            calls the api.
         */
        void PostRegister(Register model);

        /*
            This method is called when user submits the login form after entering email and password. It collects the user data
            and calls the api.
         */
        object PostLogin(Login model);
    }
}
