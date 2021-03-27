using AspNetCoreAssignment.BAL.Interface;
using AspNetCoreAssignment.DAL.Interface;
using AspNetCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAssignment.BAL
{
    public class AccountManager : IAccountManager
    {
        IAccountRepository _account;

        public AccountManager(IAccountRepository account)
        {
            _account = account;
        }

        //<summary>
        //    This api accepts user's username and password and passes it to other layers and check wether the credentails are valid or not.
        //    If credentails are valid it returns a JWT Token otherwise not.
        //</summary>
        public string Login(LoginModel model)
        {
            return _account.Login(model);
        }
    }
}
