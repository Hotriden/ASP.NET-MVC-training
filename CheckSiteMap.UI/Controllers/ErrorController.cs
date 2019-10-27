using System.Web.Mvc;

namespace CheckSiteMap.UI.Controllers
{
    /// <summary>
    /// Separated controller for handle specified
    /// methods as 404, 403 etc
    /// Created different view for each error
    /// </summary>
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