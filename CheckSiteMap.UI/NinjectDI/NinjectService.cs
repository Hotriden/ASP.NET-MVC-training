using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CheckSitemap.BLL.Interfaces;
using CheckSitemap.BLL.Services;
using CheckSitemap.DAL.Interfaces;
using CheckSitemap.DAL.Repositories;
using Ninject;

namespace CheckSiteMap.UI.NinjectDI
{
    /// <summary>
    /// Implementation of DI Ninject
    /// UOW should be binded as siteservice!!!
    /// </summary>
    public class NinjectService : IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectService()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<ISiteService>().To<SiteService>();
            _kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}