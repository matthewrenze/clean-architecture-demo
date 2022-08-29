using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApi.StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace CleanArchitecture.Service
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes); 
            
            GlobalConfiguration.Configuration.UseStructureMap(
                p => p.Scan(
                    scan => {
                        scan.TheCallingAssembly();

                        scan.WithDefaultConventions();

                        scan.AssembliesFromApplicationBaseDirectory(
                            filter => filter.FullName.StartsWith("CleanArchitecture"));                        
                }));
        }
    }
}