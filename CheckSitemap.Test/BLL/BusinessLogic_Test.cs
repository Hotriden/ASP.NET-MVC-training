using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckSitemap.BLL.BusinessModels;

namespace CheckSitemap.Test.BLL
{
    [TestClass]
    public class BusinessLogic_Test
    {
        [TestMethod]
        public void GetSiteMap_test()
        {
            var method = new GetSiteMap("www.google.com/sitemap.xml");

            Assert.IsNotNull(method.requests);
            Assert.AreEqual(method.requests.Count, 1);
        }
    }
}
