using Autofac;
using System;
using Xunit;

namespace TestAutoFac
{
    public class TestAutoFac
    {
        [Fact]
        public void RegisterToContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            builder.RegisterType<KidService>().As<IServiceKid>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<AdultService>().As<IServiceAdult>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<DatabaseContext>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
