using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.DAL.Interface
{
    public interface IAccountRepo
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
