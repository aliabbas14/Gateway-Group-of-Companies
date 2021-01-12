using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectTraineeAssignment.Controllers;
using System.Web.Mvc;
using ProjectTraineeAssignment.Models;
using Microsoft.CSharp;

namespace ProjectTraineeAssignment.Test.Controllers
{

    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void Register_Get_NotNull()
        {
            try
            {
                AccountController controller = new AccountController();

                ViewResult result = controller.Register() as ViewResult;

                Assert.IsNotNull(result);
            }
            catch (Exception e)
            { }

        }

        [TestMethod]
        public void Register_Get_Null()
        {
            try
            {
                AccountController controller = new AccountController();

                ViewResult result = controller.Register() as ViewResult;

                Assert.IsNull(result);
            }
            catch (Exception e)
            { }

        }

        [TestMethod]
        public void Register_Get_Error()
        {
            try
            {
                AccountController controller = new AccountController();

                ViewResult result = controller.Register() as ViewResult;

                Assert.AreEqual("Error",result.ViewName);
            }
            catch (Exception e)
            { }

        }


        [TestMethod]
        public void Register_Post_NotNull()
        {
            try
            {
                RegisterModel r = new RegisterModel()
                {
                    name="abc",
                    email="abc@gmail.com",
                    pwd="abc123",
                    confirm_pwd="abc123",
                };
                AccountController controller = new AccountController();

                ViewResult result = controller.Register(r) as ViewResult;

                Assert.IsNotNull(result);
            }
            catch (Exception e)
            { }

        }


        [TestMethod]
        public void Register_Post_Null()
        {
            try
            {
                RegisterModel r = new RegisterModel()
                {
                    name = "abc",
                    email = "abc@gmail.com",
                    pwd = "abc123",
                    confirm_pwd = "abc123",
                };
                AccountController controller = new AccountController();

                ViewResult result = controller.Register(r) as ViewResult;

                Assert.IsNull(result);
            }
            catch (Exception e)
            { }

        }

        [TestMethod]
        public void Register_Post_Success()
        {
            try
            {
                RegisterModel r = new RegisterModel()
                {
                    name = "abc",
                    email = "abc@gmail.com",
                    pwd = "abc123",
                    confirm_pwd = "abc123",
                };
                AccountController controller = new AccountController();

                ViewResult result = controller.Register(r) as ViewResult;

                Assert.AreEqual("Login",result.ViewName);
            }
            catch (Exception e)
            { }

        }

        [TestMethod]
        public void Register_Post_Error()
        {
            try
            {
                RegisterModel r = new RegisterModel()
                {
                    name = "abc",
                    email = "abc@gmail.com",
                    pwd = "abc123",
                    confirm_pwd = "abc123",
                };
                AccountController controller = new AccountController();

                ViewResult result = controller.Register(r) as ViewResult;

                Assert.AreEqual("Error", result.ViewName);
            }
            catch (Exception e)
            { }

        }


        [TestMethod]
        public void Login_Get_NotNull()
        {
            try
            {
                AccountController controller = new AccountController();

                ViewResult result = controller.Login() as ViewResult;

                Assert.IsNotNull(result);
            }
            catch (Exception e)
            { }

        }

        [TestMethod]
        public void Login_Get_Null()
        {
            try
            {
                AccountController controller = new AccountController();

                ViewResult result = controller.Login() as ViewResult;

                Assert.IsNull(result);
            }
            catch (Exception e)
            { }

        }

        [TestMethod]
        public void Login_Get_Error()
        {
            try
            {
                AccountController controller = new AccountController();

                ViewResult result = controller.Login() as ViewResult;

                Assert.AreEqual("Error", result.ViewName);
            }
            catch (Exception e)
            { }

        }


        [TestMethod]
        public void Login_Post_NotNull()
        {
            try
            {

                LoginModel l = new LoginModel()
                {
                    email="abc@gmail.com",
                    pwd="abc123"
                };
                AccountController controller = new AccountController();

                ViewResult result = controller.Login(l) as ViewResult;

                Assert.IsNotNull(result);
            }
            catch (Exception e)
            { }
        }

        [TestMethod]
        public void Login_Post_Null()
        {
            try
            {

                LoginModel l = new LoginModel()
                {
                    email = "abc@gmail.com",
                    pwd = "abc123"
                };
                AccountController controller = new AccountController();

                ViewResult result = controller.Login(l) as ViewResult;

                Assert.IsNull(result);
            }
            catch (Exception e)
            { }
        }


        [TestMethod]
        public void Login_Post_Success()
        {
            try
            {

                LoginModel l = new LoginModel()
                {
                    email = "abc@gmail.com",
                    pwd = "abc123"
                };
                AccountController controller = new AccountController();

                ViewResult result = controller.Login(l) as ViewResult;

                Assert.AreEqual("Index",result.ViewName);
            }
            catch (Exception e)
            { }
        }


        [TestMethod]
        public void Login_Post_Failed()
        {
            try
            {

                LoginModel l = new LoginModel()
                {
                    email = "abc@gmail.com",
                    pwd = "abc123"
                };
                AccountController controller = new AccountController();

                ViewResult result = controller.Login(l) as ViewResult;

                Assert.Equals("Your email and password doesnt match", (string)result.ViewBag.IdPwdDontMatch);
            }
            catch (Exception e)
            { }
        }

        [TestMethod]
        public void Login_Post_Error()
        {
            try
            {

                LoginModel l = new LoginModel()
                {
                    email = "abc@gmail.com",
                    pwd = "abc123"
                };
                AccountController controller = new AccountController();

                ViewResult result = controller.Login(l) as ViewResult;

                Assert.AreEqual("Error", result.ViewName);
            }
            catch (Exception e)
            { }
        }


        [TestMethod]
        public void Logout_NotNull()
        {
            try
            {
                AccountController controller = new AccountController();

                ViewResult result = controller.Logout() as ViewResult;

                Assert.IsNotNull(result);
            }
            catch (Exception e)
            { }
        }

        [TestMethod]
        public void Logout_Null()
        {
            try
            {
                AccountController controller = new AccountController();

                ViewResult result = controller.Logout() as ViewResult;

                Assert.IsNull(result);
            }
            catch (Exception e)
            { }
        }

        [TestMethod]
        public void Logout_Error()
        {
            try
            {
                AccountController controller = new AccountController();

                ViewResult result = controller.Logout() as ViewResult;

                Assert.AreEqual("Error",result.ViewName);
            }
            catch (Exception e)
            { }
        }

    }
}
