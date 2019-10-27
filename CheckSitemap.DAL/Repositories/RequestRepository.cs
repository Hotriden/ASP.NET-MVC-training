using System.Collections.Generic;
using CheckSitemap.DAL.Entities;
using CheckSitemap.DAL.Interfaces;
using CheckSitemap.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace CheckSitemap.DAL.Repositories
{
    /// <summary>
    /// DON'T USED
    /// </summary>
    public class RequestRepository:IRepository<Request>
    {
        private RequestContext context;

        public RequestRepository(RequestContext cont)
        {
            context = cont;
        }

        public IEnumerable<Request> GetAll()
        {
            return context.Requests;
        }

        public Request Get(int id)
        {
            return context.Requests.Find(id);
        }

        public void Create(Request req)
        {
            context.Requests.Add(req);
        }

        public void Update(Request req)
        {
            context.Entry(req).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Request req = context.Requests.Find(id);
            if (req != null)
                context.Requests.Remove(req);
        }
    }
}
