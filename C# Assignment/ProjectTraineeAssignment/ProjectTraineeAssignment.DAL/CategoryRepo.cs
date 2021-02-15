using ProjectTraineeAssignment.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTraineeAssignment.DAL
{
    public class CategoryRepo : ICategoryRepo
    {

        /*
         This api returns the list of categories of product.
             */
        public object Get()
        {
            try
            {
                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var data = context.tbl_category.Select(x => new { x.category_id, x.name }).ToList();
                    return data;
                }
            }
            catch (Exception e)
            {
                return new object();
            }
        }
    }
}
