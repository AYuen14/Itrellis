using Autofac;
using Autofac.Integration.Mvc;
using CarDealership.App_Start.AutofacModules;
using CarDealership.App_Start.Utility;
using CarDealership.App_Start.Utility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            RegisterTypes(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        /// Registers the types.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //App config injection
            builder.RegisterType<AppConfig>().As<IAppConfig>();

            //Log4Net injection
            builder.RegisterModule(new LogInjectionModule());

            //Navigation Categories
            //builder.RegisterType<NavigationQueryFactory>().As<INavigationQueryFactory>();
            //builder.RegisterType<NavigationService>().As<INavigationService>();
        }

    }
}