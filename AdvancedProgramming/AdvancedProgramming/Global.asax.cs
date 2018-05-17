using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AdvancedProgramming.Controllers;
using AdvancedProgramming.DbContext;
using AdvancedProgramming.Interfaces;
using AdvancedProgramming.Services;
using Autofac;
using Autofac.Integration.Mvc;

namespace AdvancedProgramming
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            CreateBuilder();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            builder.RegisterType<KidService>().As<IServiceKid>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<AdultService>().As<IServiceAdult>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<KidService>().As<IFilterKid>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<AdultService>().As<IFilterAdult>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<DatabaseContext>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void CreateBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            builder.RegisterType<DatabaseContext>();

            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var loadedPaths = loadedAssemblies.Where(n => !n.IsDynamic).Select(a => a.Location).ToArray();

            Assembly.Load(Assembly.GetExecutingAssembly().FullName);

            var assembliesList = loadedAssemblies.ToArray();

            builder
                .RegisterAssemblyTypes(assembliesList)
                .AssignableTo<IDependency>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
