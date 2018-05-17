using AdvancedProgramming.DbContext;
using AdvancedProgramming.Interfaces;
using AdvancedProgramming.Services;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xunit;

namespace AdvancedProgramming.Test
{
    public class TestAutoFac
    {
        [Fact]
        public void TestRegisterKidService()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<KidService>().As<IServiceKid>().SingleInstance().PreserveExistingDefaults();
            var resolver = builder.Build();

            var resolvedInstance = resolver.Resolve<IServiceKid>();
            var exceptedInstance = (new KidService()) as IServiceKid;

            Assert.Equal(exceptedInstance.GetType(), resolvedInstance.GetType());
        }

        [Fact]
        public void TestRegisterAdultService()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AdultService>().As<IServiceAdult>().SingleInstance().PreserveExistingDefaults();
            var resolver = builder.Build();

            var resolvedInstance = resolver.Resolve<IServiceAdult>();
            var exceptedInstance = (new AdultService()) as IServiceAdult;

            Assert.Equal(exceptedInstance.GetType(), resolvedInstance.GetType());
        }

        [Fact]
        public void TestRegisterFilterKidService()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<KidService>().As<IFilterKid>().SingleInstance().PreserveExistingDefaults();
            var resolver = builder.Build();

            var resolvedInstance = resolver.Resolve<IFilterKid>();
            var exceptedInstance = (new KidService()) as IFilterKid;

            Assert.Equal(exceptedInstance.GetType(), resolvedInstance.GetType());
        }

        [Fact]
        public void TestRegisterDbContext()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DatabaseContext>();
            var resolver = builder.Build();

            var resolvedInstance = resolver.Resolve<DatabaseContext>();
            var exceptedInstance = new DatabaseContext();

            Assert.Equal(exceptedInstance.GetType(), resolvedInstance.GetType());
        }

        public bool RegisterContainer()
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterControllers(typeof(MvcApplication).Assembly);
                builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
                builder.RegisterType<KidService>().As<IServiceKid>().SingleInstance().PreserveExistingDefaults();
                builder.RegisterType<AdultService>().As<IServiceAdult>().SingleInstance().PreserveExistingDefaults();
                builder.RegisterType<DatabaseContext>();
                var container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [Fact]
        public void TestRegisterContainer()
        {
            Assert.True(RegisterContainer());
        }
    }
}