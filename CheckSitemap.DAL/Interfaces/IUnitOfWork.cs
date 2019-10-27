using System;
using CheckSitemap.DAL.Entities;

namespace CheckSitemap.DAL.Interfaces
{
    /// <summary>
    /// IRepo<Request> didn't implement cose of
    /// dont need to use without site's
    /// </summary>
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Request> Requests { get; }
        IRepository<Site> Sites { get; }
        void Save();
    }
}
