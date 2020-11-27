using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceControlAssignment1.Models;

namespace SourceControlAssignment1.Db
{
    /*
     This class is used for database related operations which in our case is inserting form data into database.
         */
    public class DBOperations
    {

        /*
         This method accepts RegistrationFormModel object as parameter which contains form data and inserts that data
         into database.
             */
        public void addNewRegistrationForm(RegistrationFormModel r)
        {
            try
            {
                using (var context = new SourceControlAssignment1Entities())
                {

                    var reg = new RegistrationForm()
                    {
                        first_name = r.first_name,
                        last_name = r.last_name,
                        email = r.email,
                        phone = r.phone,
                        gender = r.gender,
                        password = r.confirm_password,
                        city = r.city,
                        state = r.state

                    };
                    context.RegistrationForms.Add(reg);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
