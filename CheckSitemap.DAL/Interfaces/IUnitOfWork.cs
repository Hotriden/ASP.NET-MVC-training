using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckSitemap.DAL.Entities;

namespace CheckSitemap.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Request> Requests { get; }
        IRepository<Site> Sites { get; }
        void Save();
    }
}
