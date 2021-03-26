using AspNetCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAssignment.DAL.Interface
{
    public interface IAccountRepository
    {
        string Login(LoginModel model);
    }
}
