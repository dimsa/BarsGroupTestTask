using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataAccess;
using DataAccess.Services;
using WebApp.Controllers;

namespace WebApp.Ioc
{
    public class WatchInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IHttpController>()
                .LifestylePerWebRequest()); 

            container.Register(
                Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>()
            );

            container.Register(
                Component.For<DataService>().ImplementedBy<DataService>()
            );


        }
    }
}