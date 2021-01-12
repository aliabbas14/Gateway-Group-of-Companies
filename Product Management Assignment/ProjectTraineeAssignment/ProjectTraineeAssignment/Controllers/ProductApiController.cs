using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTraineeAssignment.Models;
using System.IO;

namespace ProjectTraineeAssignment.Controllers
{
    public class ProductApiController : ApiController
    {
        /*
            This api returns all the product in the tbl_products table in the database in seralized form.
             */
        public IHttpActionResult Get()
        {
            try
            {
                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var data = context.tbl_product.Where(x => x.is_deleted == false).Select(x => new ProductModel()
                    {
                        id = x.product_id,
                        name = x.name,
                        category = new CategoryModel()
                        {
                            id = x.category_id,
                            name = x.tbl_category.name
                        },
                        price = x.price,
                        quantity = x.quantity,
                        short_description = x.short_description,
                        long_description = x.long_description,
                        small_image = x.small_image,
                        large_image = x.large_image,

                    }).ToList();
                    return Ok(JsonConvert.SerializeObject(data));
                }
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
            }

        /*
            This api accepts one int argument which is the product id and returns all the details of that particular product in serailized form.
             */
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var data = context.tbl_product.Where(x => x.product_id == id && x.is_deleted == false).Select(x => new ProductModel()
                    {
                        id = x.product_id,
                        name = x.name,
                        category = new CategoryModel()
                        {
                            id = x.category_id,
                            name = x.tbl_category.name
                        },
                        price = x.price,
                        quantity = x.quantity,
                        short_description = x.short_description,
                        long_description = x.long_description,
                        small_image = x.small_image,
                        large_image = x.large_image,

                    }).FirstOrDefault();

                    return Ok(JsonConvert.SerializeObject(data));
                }
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }


        /*
            This api accepts one argument which is object of ProductModel model and inserts the product into tbl_products table.
             */
        [HttpPost]
        public IHttpActionResult Post([FromBody]ProductModel model)
        {
            try
            {
                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    tbl_product product = new tbl_product()
                    {
                        name = model.name,
                        category_id = model.category.id,
                        price = model.price,
                        quantity = model.quantity,
                        short_description = model.short_description,
                        long_description = model.long_description,
                        small_image = model.small_image,
                        large_image = model.large_image,
                        created_by = 1,
                        created_date = DateTime.Now,
                        updated_by = 1,
                        updated_date = DateTime.Now
                    };

                    context.tbl_product.Add(product);
                    context.SaveChanges();

                    return Ok();
                }
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }

        /*
            This api accepts one argument which is object of ProductModel model and updates the product into tbl_products table.
             */
        public IHttpActionResult Put([FromBody]ProductModel model)
        {
            try
            {

                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var data = context.tbl_product.Where(x => x.product_id == model.id).FirstOrDefault();

                    data.name = model.name;
                    data.category_id = model.category.id;
                    data.price = model.price;
                    data.quantity = model.quantity;
                    data.short_description = model.short_description;
                    data.long_description = model.long_description;
                    if (model.small_image != null)
                        data.small_image = model.small_image;
                    if (model.large_image != null)
                        data.large_image = model.large_image;
                    data.updated_date = DateTime.Now;

                    context.SaveChanges();
                    return Ok();
                }

            }
            catch(Exception e)
            {
                return InternalServerError();
            }     
        }

        /*
         This api accepts one int argument which is the product id and deletes that particular product.
             */
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var data = context.tbl_product.Where(x => x.product_id == id).FirstOrDefault();

                    data.is_deleted = true;
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }

    }
}
