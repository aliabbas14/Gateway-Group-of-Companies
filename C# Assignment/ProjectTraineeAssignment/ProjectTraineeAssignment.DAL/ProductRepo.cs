using ProjectTraineeAssignment.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTraineeAssignment.Models;
using AutoMapper;

namespace ProjectTraineeAssignment.DAL
{
    public class ProductRepo : IProductRepo
    {

        /*
         This api accepts one int argument which is the product id and deletes that particular product.
             */
        public void Delete(int id)
        {
            try
            {
                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var data = context.tbl_product.Where(x => x.product_id == id).FirstOrDefault();

                    data.is_deleted = true;
                    context.SaveChanges();
                    
                }
            }
            catch (Exception e)
            {
               
            }
        }


        /*
            This api returns all the product in the tbl_products table in the database in seralized form.
             */
        public object Get()
        {
            try
            {
                using (var context = new ProjectTraineeAssignmentEntities())
                {
                    var data = context.tbl_product.Where(x => x.is_deleted == false).Select(x => 
                    
                    
                    new ProductModel()
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
                    return data;
                }
            }
            catch (Exception e)
            {
                return new object();
            }
        }


        /*
            This api accepts one int argument which is the product id and returns all the details of that particular product in serailized form.
             */
        public object Get(int id)
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

                    return data;
                }
            }
            catch (Exception e)
            {
                return new object();
            }
        }


        /*
            This api accepts one argument which is object of ProductModel model and inserts the product into tbl_products table.
             */
        public void Post(ProductModel model)
        {
            try
            {
                using (var context = new ProjectTraineeAssignmentEntities())
                {

                    var product = Mapper.Map<ProductModel, tbl_product>(model);
                    product.created_by = 1;
                    product.created_date = DateTime.Now;
                    product.updated_by = 1;
                    product.updated_date = DateTime.Now;
                    

                    context.tbl_product.Add(product);
                    context.SaveChanges();

                    
                }
            }
            catch (Exception e)
            {
               
            }
        }


        /*
            This api accepts one argument which is object of ProductModel model and updates the product into tbl_products table.
             */
        public void Put(ProductModel model)
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
                   
                }

            }
            catch (Exception e)
            {
                
            }
        }
    }
}
