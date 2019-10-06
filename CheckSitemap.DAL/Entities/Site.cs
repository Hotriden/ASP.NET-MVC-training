using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CheckSitemap.DAL.Entities
{
    public class Site
    {
        public Site()
        {
            Requests = new List<Request>();
        }
        public int Id { get; set; }

        public string Url { get; set; }

        public string RequestIp { get; set; }

        [MinLength(5)]
        public double SummaryTime { get; set; }

        public int SiteAmount { get; set; }

        public DateTime CreateTime { get; set; }

        public List<Request> Requests { get; set; }
    }
}
