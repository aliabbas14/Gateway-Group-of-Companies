using ProjectTraineeAssignment.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTraineeAssignment.Models;
using ProjectTraineeAssignment.DAL.Interface;
using ProjectTraineeAssignment.DAL;

namespace ProjectTraineeAssignment.BAL
{
    public class Product : IProduct
    {
        IProductRepo _product;
        public Product(IProductRepo product)
        {
            _product= product;
        }

        /*
         This api accepts one int argument which is the product id and deletes that particular product.
             */
        public void Delete(int id)
        {
            _product.Delete(id);
        }


        /*
            This api returns all the product in the tbl_products table in the database in seralized form.
             */
        public object Get()
        {
            return _product.Get();
        }


        /*
            This api accepts one int argument which is the product id and returns all the details of that particular product in serailized form.
             */
        public object Get(int id)
        {
            return _product.Get(id);
        }


        /*
            This api accepts one argument which is object of ProductModel model and inserts the product into tbl_products table.
             */
        public void Post(ProductModel model)
        {
            _product.Post(model);
        }

        /*
            This api accepts one argument which is object of ProductModel model and updates the product into tbl_products table.
             */
        public void Put(ProductModel model)
        {
            _product.Put(model);
        }
    }
}
