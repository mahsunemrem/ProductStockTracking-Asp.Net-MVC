using ProductStockTracking.Business.DepandencyResolvers.Ninject;
using ProductStockTracking.Core.Utilities.Mvc.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductStockTracking.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
        }
    }
}
