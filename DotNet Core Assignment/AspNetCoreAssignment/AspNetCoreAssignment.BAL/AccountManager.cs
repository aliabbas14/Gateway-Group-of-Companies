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

        public string Login(LoginModel model)
        {
            return _account.Login(model);
        }
    }
}
