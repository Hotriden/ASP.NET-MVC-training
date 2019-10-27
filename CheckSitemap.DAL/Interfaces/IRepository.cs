using System.Collections.Generic;

namespace CheckSitemap.DAL.Interfaces
{
    /// <summary>
    /// CRUD operation for communicate with DB
    /// T aimed on SiteRepository btw could be requestRepo
    /// same as siterepo
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int indentity);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
