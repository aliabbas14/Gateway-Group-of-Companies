using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTraineeAssignment.DAL.Interface
{
    public interface ICategoryRepo
    {

        /*
         This api returns the list of categories of product.
             */
        object Get();
    }
}
