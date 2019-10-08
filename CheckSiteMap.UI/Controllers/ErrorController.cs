using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckSiteMap.UI.Controllers
{
    public sealed class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult EmptyData()
        {
            return View();
        }
    }
}