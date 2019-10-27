using CheckSitemap.DAL.Entities;
using System.Collections.Generic;

namespace CheckSitemap.BLL.BusinessModels
{
    /// <summary>
    /// Simple counter of spent time
    /// of all request on list of requests
    /// </summary>
    public class TimeCounter
    {
        public double time;

        public TimeCounter(IList<Request> listRequest)
        {
            foreach (Request request in listRequest)
            {
                time += request.TimeRequest;
            }
        }
    }
}
