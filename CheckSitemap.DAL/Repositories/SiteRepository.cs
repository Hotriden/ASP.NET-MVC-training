using CheckSitemap.DAL.EF;
using CheckSitemap.DAL.Entities;
using CheckSitemap.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CheckSitemap.DAL.Repositories
{
    public class SiteRepository : IRepository<Site>
    {
        private readonly RequestContext context;

        public SiteRepository(RequestContext cont)
        {
            context = cont;
        }
        // Add site to Db
        public void Create(Site item)
        {
            context.Sites.Add(item);
        }

        //Remove from site from DB by Id
        public void Delete(int id)
        {
            Site site = context.Sites.Find(id);
            if (site != null)
                context.Sites.Remove(site);
        }

        public Site Get(int id)
        {
            var request = context.Sites.Where(t => t.Id == id).Include(t => t.Requests).First();
            Site site = new Site() { Requests = request.Requests.OrderByDescending(t => t.TimeRequest).ToList(),
                Id = request.Id, RequestIp = request.RequestIp, SummaryTime = request.SummaryTime, Url = request.Url, CreateTime=request.CreateTime };
            return site;
        }

        // For get all site on one table
        public IEnumerable<Site> GetAll()
        {
            return context.Sites;
        }

        public void Update(Site item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
