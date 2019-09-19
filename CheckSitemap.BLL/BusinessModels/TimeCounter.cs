using CheckSitemap.BLL.DTO;
using CheckSitemap.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSitemap.BLL.BusinessModels
{
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
