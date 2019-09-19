using System.Collections.Generic;

namespace CheckSiteMap.UI.Models
{
    public class SiteViewModel
    {
        public SiteViewModel()
        {
            RequestsVM = new List<RequestViewModel>();
        }
        public int Id { get; set; }

        public string Url { get; set; }

        public string RequestIp { get; set; }

        public double SummaryTime { get; set; }

        public List<RequestViewModel> RequestsVM { get; set; }
    }
}