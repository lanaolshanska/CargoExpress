using Delivery.Website.App_Start;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Delivery.Website
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            IocCConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Response.Clear();

            if (exception != null)
            {
                Server.ClearError();
                Response.Redirect(String.Format("~/Error/Unexpected/?message={0}", exception.Message));
            }
        }
    }
}
