using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTraineeAssignment.Models;
using System.IO;
using ProjectTraineeAssignment.BAL.Interface;
using ProjectTraineeAssignment.BAL;

namespace ProjectTraineeAssignment.Controllers
{
    public class ProductApiController : ApiController
    {
        IProduct _product;
        public ProductApiController(IProduct product)
        {
            _product = product;
        }



        /*
            This api returns all the product in the tbl_products table in the database in seralized form.
             */
        public IHttpActionResult Get()
        {
            return Ok(_product.Get());
        }

        /*
            This api accepts one int argument which is the product id and returns all the details of that particular product in serailized form.
             */
        public IHttpActionResult Get(int id)
        {
            return Ok(_product.Get(id));
        }


        /*
            This api accepts one argument which is object of ProductModel model and inserts the product into tbl_products table.
             */
        [HttpPost]
        public IHttpActionResult Post([FromBody]ProductModel model)
        {
            _product.Post(model);
            return Ok();
        }

        /*
            This api accepts one argument which is object of ProductModel model and updates the product into tbl_products table.
             */
        public IHttpActionResult Put([FromBody]ProductModel model)
        {
            _product.Put(model);
            return Ok();
        }

        /*
         This api accepts one int argument which is the product id and deletes that particular product.
             */
        public IHttpActionResult Delete(int id)
        {
            _product.Delete(id);
            return Ok();
        }

    }
}
