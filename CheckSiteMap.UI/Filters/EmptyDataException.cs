using System.Web.Mvc;

namespace CheckSiteMap.UI.Filters
{
    /// <summary>
    /// As main handler of all types exceptions 
    /// </summary>
    public class EmptyDataException: FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                filterContext.Result = new RedirectResult("/Error/EmptyData");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}