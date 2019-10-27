using CheckSiteMap.UI.Filters;
using System.Web.Mvc;

namespace CheckSiteMap.UI
{
    public class FilterConfig
    {
        /// <summary>
        /// Added error handlers
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new EmptyDataException());
            filters.Add(new PageNotFoundException());
        }
    }
}
