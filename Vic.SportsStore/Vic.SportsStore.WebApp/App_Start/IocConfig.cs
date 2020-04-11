using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.WebApp.Abstract;
using Vic.SportsStore.WebApp.Concrete;

namespace Vic.SportsStore.WebApp
{
    public class IocConfig
    {
        public static void ConfigIoc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();


            ////////////////////////////////
            // My added RegisterInstance //
            ///////////////////////////////
            //builder.RegisterInstance<IProductsRepository>(new InMemoryProductsRepository()).PropertiesAutowired();
            builder.RegisterInstance<IProductsRepository>(new EFProductsRepository()).PropertiesAutowired();

            builder.RegisterInstance<IOrderProcessor>(new EmailOrderProcessor(new EmailSettings())).PropertiesAutowired();

            builder.RegisterType<EFDbContext>();

            //builder.RegisterInstance<IAuthProvider>(new FormsAuthProvider()).PropertiesAutowired();
            //builder.RegisterInstance<IAuthProvider>(new InMemoryAuthProvider()).PropertiesAutowired();
            builder.RegisterType<EFAuthProvider>().PropertiesAutowired().As<IAuthProvider>().PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}