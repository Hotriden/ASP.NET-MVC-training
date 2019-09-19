using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CheckSitemap.BLL.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }

        public string SitemapUrl { get; set; }

        public double TimeRequest { get; set; }
    }
}
