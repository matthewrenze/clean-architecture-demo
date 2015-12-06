using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace CleanArchitecture.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();

            ViewEngines.Engines.Add(new CustomRazorViewEngine());

            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
