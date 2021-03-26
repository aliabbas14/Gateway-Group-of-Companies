using AspNetCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAssignment.BAL.Interface
{
    public interface IAccountManager
    {
        string Login(LoginModel model);
    }
}
