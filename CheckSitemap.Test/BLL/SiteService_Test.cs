using System;
using CheckSitemap.BLL.Interfaces;
using CheckSitemap.DAL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CheckSitemap.Test.BLL
{
    [TestClass]
    public class SiteService_Test
    {
        [TestMethod]
        public void Create_site_test()
        {
            var repos = new Mock<IUnitOfWork>();
            var mock = new Mock<ISiteService>();
            mock.Setup(x => x.CreateSite(It.IsAny<string>())).Verifiable();

        }
    }
}
