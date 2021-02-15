using DotNetAssignment.DAL.Interface;
using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAssignment.DAL
{
    public class AccountRepo : IAccountRepo
    {

        /*
            This method is called when user submits the login form after entering email and password. It collects the user data
            and calls the api.
         */
        public object PostLogin(Login model)
        {
            using(var context=new DotNetAssignmentEntities())
            {
                var result=context.Customers.Where(x => x.Email == model.Email && x.Pwd == model.Password).Select(x => new { x.Id, x.Name }).FirstOrDefault();
                return result;
            }
        }

        /*
            This method is called when user fills the registration form and submits the form. It collects the user's form data and
            calls the api.
         */
        public void PostRegister(Register model)
        {

            using (var context = new DotNetAssignmentEntities())
            {
                var data = new Customer()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    HomePhone = model.HomePhone,
                    Pwd = model.Pwd,
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    Zipcode = model.Zipcode
                };
            context.Customers.Add(data);
                context.SaveChanges();
            }
        }
    }
}
