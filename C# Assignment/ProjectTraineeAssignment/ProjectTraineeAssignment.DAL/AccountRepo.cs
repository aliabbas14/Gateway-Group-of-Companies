using ProjectTraineeAssignment.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTraineeAssignment.Models;
using System.Security.Cryptography;
using ProjectTraineeAssignment;
using AutoMapper;

namespace ProjectTraineeAssignment.DAL
{
    public class AccountRepo : IAccountRepo
    {

        /*
         This api is called when user logs in into our system. This api accepts LoginModel which contains email and password as properties and 
         compares the email and password in the database and returns user_id(Primary key) and user name if the credentials are correct.
             */
        public object PostLogin(LoginModel model)
        {
            try
            {
                SHA512 shaM = new SHA512Managed();
                var hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(model.pwd));


                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var result = context.tbl_user.Where(x => x.email == model.email && x.pwd == hash).Select(x => new { x.user_id, x.name }).FirstOrDefault();

                        return result;
                }
            }
            catch (Exception e)
            {
                return new object();
            }
        }


        /*
        This api is called when user fills the registration form and clicks on submit button. This api inserts the user's registration data into
        the database and returns IHttpActionResult.
            */
        public void PostRegister(RegisterModel model)
        {
            try
            {
                SHA512 shaM = new SHA512Managed();
                var hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(model.pwd));

                using (var context = new ProjectTraineeAssignmentEntities())
                {

                    var data=Mapper.Map<RegisterModel,tbl_user>(model);
                    data.pwd = hash;
                    data.created_date = DateTime.Now;
                    data.updated_date = DateTime.Now;

                   

                    context.tbl_user.Add(data);
                    context.SaveChanges();
                   
                }
            }
            catch (Exception e)
            {
            }
        }
    }

}
