using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace H2H_WebAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ParseClient.Initialize("5MFXNBCly5I4Do6W0lQSk5ztXjJZWGNweVfIzfsM", "dHdvLiUhsrfhW2ccbVYlvu5CMqH1K0VLpAfNzOqh");

        }


    }
}
