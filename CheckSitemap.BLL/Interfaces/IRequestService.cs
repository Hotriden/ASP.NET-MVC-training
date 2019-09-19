using CheckSitemap.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSitemap.BLL.Interfaces
{
    public interface IRequestService:IDisposable
    {
        IEnumerable<RequestDTO> GetRequests(SiteDTO site);
    }
}
