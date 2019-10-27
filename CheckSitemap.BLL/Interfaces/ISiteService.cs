using CheckSitemap.BLL.DTO;
using System;
using System.Collections.Generic;

namespace CheckSitemap.BLL.Interfaces
{
    /// <summary>
    /// Main functions of business logic path of application
    /// which gona be used for interaction under UI
    /// with data base and appliaction entities
    /// </summary>
    public interface ISiteService:IDisposable
    {
        void CreateSite(string url);
        SiteDTO GetSite(int id);
        IEnumerable<SiteDTO> GetSites();
        int GetLast();
        void DeleteSite(int id);
    }
}
