using ProjectTraineeAssignment.BAL;
using ProjectTraineeAssignment.BAL.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ProjectTraineeAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IAccount, Account>();
            container.RegisterType<ICategory, Category>();
            container.RegisterType<IProduct, Product>();
            container.AddNewExtension<Helper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}