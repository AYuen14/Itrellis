namespace CarDealership
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using CarDealership.App_Start;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();
            AutofacConfig.RegisterAutofac();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
