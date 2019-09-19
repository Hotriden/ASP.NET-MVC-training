﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckSitemap.DAL.Entities;
using CheckSitemap.DAL.Interfaces;
using CheckSitemap.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace CheckSitemap.DAL.Repositories
{
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

        public IEnumerable<Request> GetById(int siteId)
        {
            return context.Requests.Where(t => t.site.Id == siteId);
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
