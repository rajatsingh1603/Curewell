using Curewell.DAL;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Curewell.Backend
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

             container.RegisterType<IDoctor, CureWellRepository>();
            container.RegisterType<ISpecialization, CureWellRepository>();
            container.RegisterType<ISurgery, CureWellRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}