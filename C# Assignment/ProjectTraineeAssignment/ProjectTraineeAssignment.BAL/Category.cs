using ProjectTraineeAssignment.BAL.Interface;
using ProjectTraineeAssignment.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTraineeAssignment.BAL
{
    public class Category : ICategory
    {
        ICategoryRepo _cat;
        public Category(ICategoryRepo cat)
        {
            _cat = cat;
        }

        /*
         This api returns the list of categories of product.
             */
        public object Get()
        {
            return _cat.Get();
        }
    }
}
