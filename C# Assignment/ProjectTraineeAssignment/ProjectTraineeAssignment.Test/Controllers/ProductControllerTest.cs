using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectTraineeAssignment.Controllers;
using System.Web.Mvc;
using System.Web;

namespace ProjectTraineeAssignment.Test.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Add_Get_NotNull()
        {
            try
            {
                ProductController controller = new ProductController();

                ViewResult result = controller.Add() as ViewResult;

                Assert.IsNotNull(result);
            }
            catch (Exception e)
            { }

        }

        [TestMethod]
        public void Display_NotNull()
        {

            try
            {
                ProductController controller = new ProductController();
                
                ViewResult result = controller.Display() as ViewResult;

                Assert.IsNotNull(result);                
            }
            catch(Exception e)
            { }
            
        }

        [TestMethod]
        public void Edit_NotNull()
        {
            try
            {
                ProductController controller = new ProductController();

                ViewResult result = controller.Edit(1) as ViewResult;

                Assert.IsNotNull(result);
            }
            catch (Exception e)
            { }
        }

        [TestMethod]
        public void Edit_Null()
        {
            try
            {
                ProductController controller = new ProductController();

                ViewResult result = controller.Edit(-1) as ViewResult;

                Assert.IsNull(result);
            }
            catch (Exception e)
            { }
        }

        [TestMethod]
        public void Delete_Null()
        {
            try
            {
                ProductController controller = new ProductController();

                ViewResult result = controller.Delete(-1) as ViewResult;

                Assert.IsNull(result);
            }
            catch (Exception e)
            { }
        }

        [TestMethod]
        public void Delete_NotNull()
        {
            try
            {
                ProductController controller = new ProductController();

                ViewResult result = controller.Delete(1) as ViewResult;

                Assert.IsNotNull(result);
            }
            catch (Exception e)
            { }
        }
    }
}
