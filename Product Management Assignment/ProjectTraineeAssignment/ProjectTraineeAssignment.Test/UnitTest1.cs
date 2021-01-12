using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectTraineeAssignment;
using ProjectTraineeAssignment.Controllers;
using System.Web.Mvc;
using System.Web;

namespace ProjectTraineeAssignment.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            AccountController controller = new AccountController();
            
            ViewResult result = controller.Register() as ViewResult;
            Assert.IsNull(result);
        }
    }
}
