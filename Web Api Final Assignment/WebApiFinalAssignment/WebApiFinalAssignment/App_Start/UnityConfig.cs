using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebApiFinalAssignment.BAL;
using WebApiFinalAssignment.BAL.Interface;

namespace WebApiFinalAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IHotel, Hotel>();
            container.RegisterType<IRoom, Room>();
            container.AddNewExtension<UnityHelper>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}