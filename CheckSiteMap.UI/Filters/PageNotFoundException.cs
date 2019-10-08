using CheckSitemap.BLL.Infrastracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckSiteMap.UI.Filters
{
    /// <summary>
    /// Just for 404 exception
    /// </summary>
    public class PageNotFoundException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if(!filterContext.ExceptionHandled && filterContext.Exception is NotFoundException)
            {
                filterContext.Result = new RedirectResult("/Error/NotFound");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}