using System;
using CheckSitemap.DAL.Interfaces;
using CheckSitemap.DAL.EF;
using CheckSitemap.DAL.Entities;

namespace CheckSitemap.DAL.Repositories
{
    /// <summary>
    /// UOW patter with common function to make
    /// changes on db
    /// </summary>
    public class EFUnitOfWork:IUnitOfWork
    {
        private RequestContext context;
        private RequestRepository requestRepository;
        private SiteRepository siteRepository;

        public EFUnitOfWork()
        {
            context = new RequestContext();
        }

        public IRepository<Request> Requests
        {
            get
            {
                if (requestRepository == null)
                {
                    requestRepository = new RequestRepository(context);
                }
                return requestRepository;
            }
        }

        public IRepository<Site> Sites
        {
            get
            {
                if (siteRepository == null)
                {
                    siteRepository = new SiteRepository(context);
                }
                return siteRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
