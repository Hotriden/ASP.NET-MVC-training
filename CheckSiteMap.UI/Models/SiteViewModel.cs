using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckSiteMap.UI.Models
{
    public class SiteViewModel
    {
        public SiteViewModel()
        {
            RequestsVM = new List<RequestViewModel>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please input sitemap url")]
        [RegularExpression(@"\D*sitemap.xml$", ErrorMessage= "Sitemap should end with /sitemap.xml")]
        public string Url { get; set; }

        public string RequestIp { get; set; }

        public double SummaryTime { get; set; }
        public DateTime CreateTime { get; set; }

        public List<RequestViewModel> RequestsVM { get; set; }
    }
}