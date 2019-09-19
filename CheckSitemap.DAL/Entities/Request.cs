using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CheckSitemap.DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }

        public string SitemapUrl { get; set; }

        public double TimeRequest { get; set; }

        public Site site { get; set; }
    }
}
