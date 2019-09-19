using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSitemap.DAL.Entities
{
    public class User
    {
        public User()
        {
            Requests = new List<Request>();
        }
        public int Id { get; set; }

        public string Url { get; set; }

        public IList<Request> Requests { get; set; }

        public double SummaryTime { get; set; }

        public string UserIp { get; set; }

        public DateTime UserTimeRequest { get; set; }
    }
}
