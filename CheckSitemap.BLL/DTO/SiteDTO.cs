using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSitemap.BLL.DTO
{
    public class SiteDTO
    {
        public SiteDTO()
        {
            RequestsDTO = new List<RequestDTO>();
        }

        public int Id { get; set; }

        public string Url { get; set; }

        public string RequestIp { get; set; }

        public double SummaryTime { get; set; }

        public List<RequestDTO> RequestsDTO { get; set; }
    }
}
