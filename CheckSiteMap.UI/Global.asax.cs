using CheckSiteMap.UI.NinjectDI;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CheckSitemap.BLL.Infrastracture;
using Ninject;
using Ninject.Web.Mvc;
using CheckSitemap.BLL.Interfaces;
using CheckSiteMap.UI.Controllers;

namespace CheckSiteMap.UI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DependencyResolver.SetResolver(new NinjectService());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                Response.Clear();

                var rd = new RouteData();
                rd.Values["controller"] = "Error";
                rd.Values["action"] = "NotFound";

                var rc = new RequestContext(new HttpContextWrapper(Context), rd);
                var c = ControllerBuilder.Current.GetControllerFactory().CreateController(rc, "Error");
                c.Execute(rc);
            }
        }
    }

}
