using ProjectTraineeAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTraineeAssignment.BAL.Interface
{
    public interface IProduct
    {

        /*
            This api returns all the product in the tbl_products table in the database in seralized form.
             */
        object Get();

        /*
            This api accepts one int argument which is the product id and returns all the details of that particular product in serailized form.
             */
        object Get(int id);

        /*
            This api accepts one argument which is object of ProductModel model and inserts the product into tbl_products table.
             */
        void Post(ProductModel model);

        /*
            This api accepts one argument which is object of ProductModel model and updates the product into tbl_products table.
             */
        void Put(ProductModel model);

        /*
         This api accepts one int argument which is the product id and deletes that particular product.
             */
        void Delete(int id);

    }
}
