using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTraineeAssignment.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using NLog;

namespace ProjectTraineeAssignment.Controllers
{
    public class ProductController : Controller
    {
        private static Logger logger = LogManager.GetLogger("myAppLoggerRule");

        /*
          This action method is called when user tries to insert a new product. At first it checks wether user is authenticated or not otherwise 
          user is redirected to login page. It calls an api that returns all the categories of product and send that list of categories to 
          the view using viewbag.  
             */
        public ActionResult Add()
        {
            try
            {
                logger.Info("Entering Add action method (Get) of ProductController.");

                if ((string)Session["user_id"] == null)
                {
                    logger.Info("Exiting Add action method (Get) of ProductController. User not authenticated");
                    return RedirectToAction("Login", "Account");
                }
            
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51720/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("category/Get");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<string>();
                        readTask.Wait(); 
                        ViewBag.category = JsonConvert.DeserializeObject(readTask.Result);
                        logger.Info("Exiting Add action method (Get) of ProductController.");
                        return View();
                    }
                    else
                    {
                        logger.Error("Exiting Add action method (Get) of ProductController. Internal Server Error");
                        return RedirectToAction("Error","Account");
                    }
                }
                
            }
            catch(Exception e)
            {
                logger.Error("Exception (Add action method (Get) of ProductController) : " + e.Message);
                return RedirectToAction("Error","Account");
            }
        }


        /*
            This action method is called when user fills the add product form and clicks on the submit button. At first it checks wether user
            is authenticated or not otherwise user is redirected to login page. It checks all the server side validations and if validations 
            are correct then it calls the Post api of ProductApi controller to insert data into database. 
             */
        [HttpPost]
        public ActionResult Add(ProductModel productData, HttpPostedFileBase large_image, HttpPostedFileBase small_image)
        {
            try
            {
                logger.Info("Entering Add action method (Post) of ProductController.");
                if ((string)Session["user_id"] == null)
                {
                    logger.Info("Exiting Add action method (Post) of ProductController. User not authenticated");
                    return RedirectToAction("Login", "Account");
                }

                if (large_image == null)
                    productData.large_image = "";
                else
                {
                    var fileName = Path.GetFileName(large_image.FileName);
                    large_image.SaveAs(Server.MapPath("~/Images/Large/") + fileName);
                    productData.large_image = fileName;
                }
                var fileName2 = Path.GetFileName(small_image.FileName);
                small_image.SaveAs(Server.MapPath("~/Images/Small/") + fileName2);
                productData.small_image = fileName2;

                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:51720/api/");

                        var postTask = client.PostAsJsonAsync<ProductModel>("ProductApi/Post", productData);

                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            logger.Info("Exiting Add action method (Post) of ProductController. Product Added");
                            Session["ProductAdded"] = "1";
                            return RedirectToAction("Display");
                        }
                        else
                        {
                            logger.Error("Exiting Add action method (Post) of ProductController. Internal Server Error");
                            return RedirectToAction("Error", "Account");
                        }
                    }

                }
                else
                {
                    logger.Info("Exiting Add action method (Post) of ProductController. Model State Invalid");
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:51720/api/");
                        //HTTP GET
                        var responseTask = client.GetAsync("category/Get");
                        responseTask.Wait();
                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<string>();
                            readTask.Wait();
                            ViewBag.category = JsonConvert.DeserializeObject(readTask.Result);
                            return View();
                        }
                        else
                        {
                            return RedirectToAction("Error", "Account");
                        }
                    }
                }

               


            }
            catch(Exception e)
            {
                logger.Error("Exception (Add action method (Post) of ProductController) : " + e.Message);
                return RedirectToAction("Error","Account");
            }
        }

        /*
            This action method is called when user clicks on display product menu. At first it checks wether user
            is authenticated or not otherwise user is redirected to login page. It calls the Get api of ProductApi controller to get all the
            products and then sends it to the view.
             */
        public ActionResult Display()
        {
            try
            {
                if((string)Session["ProductAdded"]=="1")
                {
                    ViewBag.ProductAdded = 1;
                    Session["ProductAdded"] ="0";
                }

                if ((string)Session["ProductEdited"] == "1")
                {
                    ViewBag.ProductEdited = 1;
                    Session["ProductEdited"] = "0";
                }

                if ((string)Session["ProductDeleted"] == "1")
                {
                    ViewBag.ProductDeleted = 1;
                    Session["ProductDeleted"] = "0";
                }

                logger.Info("Entering Display action method of ProductController.");
                if ((string)Session["user_id"] == null)
                {
                    logger.Info("Exiting Display action method of ProductController. User not authenticated.");
                    return RedirectToAction("Login", "Account");
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51720/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("ProductApi/Get");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<string>();
                        readTask.Wait();
                        var p = JsonConvert.DeserializeObject<List<ProductModel>>(readTask.Result);
                        //ViewBag.category = JsonConvert.DeserializeObject(readTask.Result);
                        //List<ProductModel> pr = new List<ProductModel>(p);
                        logger.Info("Exiting Display action method of ProductController.");
                        return View(p);
                    }
                    else
                    {
                        logger.Error("Exiting Display action method of ProductController. Internal Server Error.");
                        return RedirectToAction("Error", "Account");
                    }
                }


            }
            catch(Exception e)
            {
                logger.Error("Exception (Display action method of ProductController) : " + e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        /*
            This action method is called when user clicks edit button on display page. At first it checks wether user
            is authenticated or not otherwise user is redirected to login page. It will return a view which will display a form with all the
            values filled by default.
             */
        public ActionResult Edit(int id)
        {
            try
            {
                logger.Info("Entering Edit action method (Get) of ProductController.");
                if ((string)Session["user_id"] == null)
                {
                    logger.Info("Exiting Edit action method (Get) of ProductController. User not authenticated.");
                    return RedirectToAction("Login", "Account");
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51720/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("category/Get");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<string>();
                        readTask.Wait();
                        ViewBag.category = JsonConvert.DeserializeObject(readTask.Result);

                    }
                    else
                    {
                        logger.Error("Exiting Edit action method (Get) of ProductController. Internal Server Error");
                        return RedirectToAction("Error", "Account");
                    }

                }


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51720/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("ProductApi/Get/" + id);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<string>();
                        readTask.Wait();
                        ProductModel p = JsonConvert.DeserializeObject<ProductModel>(readTask.Result);


                        ViewBag.SelectedValue = p.category.id.ToString();
                        ViewBag.small_image = p.small_image;
                        ViewBag.large_image = p.large_image;

                        logger.Info("Exiting Edit action method (Get) of ProductController.");
                        return View(p);
                    }
                    else
                    {
                        logger.Error("Exiting Edit action method (Get) of ProductController. Internal Server Error");
                        return RedirectToAction("Error", "Account");
                    }
                }
            }
            catch(Exception e)
            {
                logger.Error("Exception (Edit action method (Get) of ProductController) : " + e.Message);
                return RedirectToAction("Error", "Account");
            }
        }


        /*
            This action method is called when user submits the form on edit page. At first it checks wether user
            is authenticated or not otherwise user is redirected to login page. It then calls the Put api of ProductApi controller to update
            the product data.
             */
        [HttpPost]
        public ActionResult Edited(ProductModel model, HttpPostedFileBase large_image, HttpPostedFileBase small_image)
        {
            try
            {
                logger.Info("Entering Edit action method (Post) of ProductController.");
                if ((string)Session["user_id"] == null)
                {
                    logger.Info("Exiting Edit action method (Post) of ProductController. User not authenticated");
                    return RedirectToAction("Login", "Account");
                }
                if (large_image != null)
                {
                    var fileName = Path.GetFileName(large_image.FileName);
                    large_image.SaveAs(Server.MapPath("~/Images/Large/") + fileName);
                    model.large_image = fileName;
                }
                else
                {
                    model.large_image = null;
                }


                if (small_image != null)
                {
                    var fileName2 = Path.GetFileName(small_image.FileName);
                    small_image.SaveAs(Server.MapPath("~/Images/Small/") + fileName2);
                    model.small_image = fileName2;
                }
                else
                {
                    model.small_image = null;
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51720/api/");

                    //HTTP POST
                    var putTask = client.PutAsJsonAsync("ProductApi/Put", model);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Exiting Edit action method (Post) of ProductController. Product Updated");
                        Session["ProductEdited"] = "1";
                        return RedirectToAction("Display");
                    }
                    else
                    {
                        logger.Error("Exiting Edit action method (Post) of ProductController. Internal Server Error");
                        return RedirectToAction("Error", "Account");
                    }
                }

            }
            catch(Exception e)
            {
                logger.Error("Exception (Edit action method (Post) of ProductController) : " + e.Message);
                return RedirectToAction("Error", "Account");
            }
        }


        /*
            This action method is called when user clicks on the delete button on display page. At first it checks wether user
            is authenticated or not otherwise user is redirected to login page. It then calls the delete api of ProductApi Controller to delete 
            the product.
             */
        public ActionResult Delete(int id)
        {
            try
            {
                logger.Info("Entering Delete action method of ProductController.");
                if ((string)Session["user_id"] == null)
                {
                    logger.Info("Exiting Delete action method of ProductController. User not authenticated");
                    return RedirectToAction("Login", "Account");
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51720/api/");

                    //HTTP DELETE
                    var deleteTask = client.DeleteAsync("ProductApi/Delete/" + id);
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Exiting Delete action method of ProductController. Product Deleted.");
                        Session["ProductDeleted"] = "1";
                        return RedirectToAction("Display");
                    }
                    else
                    {
                        logger.Error("Exiting Delete action method of ProductController. Internal Server Error");
                        return RedirectToAction("Error", "Account");
                    }

                }
            }
            catch(Exception e)
            {
                logger.Error("Exception (Delete action method of ProductController) : " + e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

    }
}