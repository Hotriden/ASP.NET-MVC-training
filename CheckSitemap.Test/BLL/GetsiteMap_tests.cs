using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckSitemap.BLL.BusinessModels;
using CheckSitemap.BLL.Infrastracture;

namespace CheckSitemap.Test.BLL
{
    [TestClass]
    public class GetsiteMap_tests
    {
        [TestMethod]
        public void Test_workable_of_method()
        {
            var method = new GetSiteMap("www.google.com/sitemap.xml");

            Assert.IsNotNull(method.requests);
        }

        [TestMethod]
        public void ValidationTest()
        {
            Action action = () => new GetSiteMap("ww.google.com/sitemap.xml");

            Assert.ThrowsException<ValidationException>(action, "Site format does not approach to request");
        }
    }
}
