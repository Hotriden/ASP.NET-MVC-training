using CheckSitemap.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSitemap.BLL.Interfaces
{
    public interface ISiteService:IDisposable
    {
        void CreateSite(string url);
        SiteDTO GetSite(int id);
        IEnumerable<SiteDTO> GetSites();
        int GetLast();
        void DeleteSite(int id);
    }
}
