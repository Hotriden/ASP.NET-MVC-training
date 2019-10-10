using System;
using CheckSitemap.BLL.Interfaces;
using CheckSitemap.BLL.Services;
using CheckSitemap.DAL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using CheckSitemap.BLL.DTO;
using System.Collections.Generic;
using CheckSitemap.DAL.Repositories;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Reflection;
using CheckSitemap.DAL.Entities;

namespace CheckSitemap.Test.BLL
{
    [TestClass]
    public class SiteService_Test
    {
        Mock<IUnitOfWork> mockIUOW = new Mock<IUnitOfWork>();

        [TestMethod]
        public void Get_sites_test()
        {
            List<Site> sites = new List<Site>() {
                new Site() {
                    Id = 1,
                    RequestIp = "10.0.0.4",
                    Url = "www.google.com/sitemap.xml"
                } };

            mockIUOW.Setup(x => x.Sites.GetAll()).Returns(sites);
            var result = new SiteService(mockIUOW.Object);
            var res = result.GetSites();
            int idResult = 0;
            foreach(var b in res)
            {
                idResult += b.Id;
            }
            Assert.IsNotNull(result);
            Assert.AreEqual(idResult, 1);
        }

        [TestMethod]
        public void GetSite_test()
        {
            Site site = new Site() { Id = 1, RequestIp = "10.0.0.4", Url = "www.google.com/sitemap.xml" };

            mockIUOW.Setup(x => x.Sites.Get(1)).Returns(site);
            var result = new SiteService(mockIUOW.Object);
            var res = result.GetSite(1);

            Assert.IsNotNull(res);
            Assert.AreEqual(res.RequestIp, "10.0.0.4");
        }

        [TestMethod]
        public void GetLast_test()
        {
            Site site = new Site() { Id = 1, RequestIp = "10.0.0.4", Url = "www.google.com/sitemap.xml" };

            var result = new SiteService(mockIUOW.Object);
            var res = result.GetSite(1);

            Assert.IsNotNull(res);
            Assert.AreEqual(res.RequestIp, "10.0.0.4");
        }

        [TestMethod]
        public void Create_site_test()
        {
            HttpContext.Current = new HttpContext(
    new HttpRequest("", "http://google.com", ""),
    new HttpResponse(new StringWriter())
    );

            Site site = new Site()
            {
                RequestIp = "10.0.0.1",
                Id = 1,
                SiteAmount = 10,
                SummaryTime = 0
            };

            var siteMock = new Mock<IRepository<Site>>();
            //var mockSiteService = mockIUOW.Setup(x => x.Sites).Returns(siteMock.Object);
            mockIUOW.Setup(x => x.Sites.Create(site));
            var siteService = new SiteService(mockIUOW.Object);
            string request = "www.google.com/sitemap.xml";
            siteService.CreateSite(request);

            mockIUOW.Verify(r => r.Sites.Create(site), Times.AtLeastOnce);
        }
    }
}
