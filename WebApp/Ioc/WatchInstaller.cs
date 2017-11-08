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
            var controllers = Classes.FromThisAssembly()
                .BasedOn<BaseController>().Unless(type => type == typeof(BaseController));
            container.Register(controllers
                .LifestylePerWebRequest());

            container.Register(
                Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestylePerWebRequest()
            );

            container.Register(
                Component.For<DataService>().ImplementedBy<DataService>().LifestylePerWebRequest()
            );


        }
    }
}