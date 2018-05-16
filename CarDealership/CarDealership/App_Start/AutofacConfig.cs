namespace CarDealership.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using CarDealership.App_Start.AutofacModules;
    using CarDealership.App_Start.Utility;
    using CarDealership.App_Start.Utility.Interface;
    using CarDealership.Repository;
    using CarDealership.Repository.Interface;
    using CarDealership.Services;
    using CarDealership.Services.Interface;

    /// <summary>
    /// Autofac configuration
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// Registers the autofac IOC.
        /// </summary>
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

            //Car dealership
            builder.RegisterType<CarDealershipRepository>().As<ICarDealershipRepository>();
            builder.RegisterType<CarDealershipService>().As<ICarDealershipService>();
        }

    }
}