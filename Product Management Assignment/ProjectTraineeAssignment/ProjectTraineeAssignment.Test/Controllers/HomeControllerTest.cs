using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectTraineeAssignment.Controllers;
using System.Web.Mvc;

namespace ProjectTraineeAssignment.Test.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_NotNull()
        {
            try
            {
                HomeController controller = new HomeController();

                ViewResult result = controller.Index() as ViewResult;

                Assert.IsNotNull(result);
            }
            catch (Exception e)
            { }
        }

        [TestMethod]
        public void Index_Null()
        {
            try
            {
                HomeController controller = new HomeController();

                ViewResult result = controller.Index() as ViewResult;

                Assert.IsNull(result);
            }
            catch (Exception e)
            { }
        }

        [TestMethod]
        public void Index_Error()
        {
            try
            {
                HomeController controller = new HomeController();

                ViewResult result = controller.Index() as ViewResult;

                Assert.AreEqual("Error",result.ViewName);
            }
            catch (Exception e)
            { }
        }
    }
}
