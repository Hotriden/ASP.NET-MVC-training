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
            List<SiteDTO> sites = new List<SiteDTO>() {
                new SiteDTO() {
                    Id = 1,
                    RequestIp = "10.0.0.4",
                    Url = "www.google.com/sitemap.xml"
                } };

            var mock = new Mock<SiteService>(mockIUOW.Object);
            var result = new SiteService(mockIUOW.Object);
            var res = result.GetSites();
            int idResult = 0;
            foreach(var b in res)
            {
                idResult += b.Id;
            }
            Assert.IsNotNull(result);
            Assert.IsTrue(res == sites);
            Assert.AreEqual(idResult, 1);
        }

        [TestMethod]
        public void GetSite_test()
        {
            Site site = new Site() { Id = 1, RequestIp = "10.0.0.4", Url = "www.google.com/sitemap.xml" };
            var repo = new EFUnitOfWork();
            var siteService = new SiteService(repo);
            repo.Sites.Create(site);
            var res = siteService.GetSite(1);

            Assert.IsNotNull(res);
            Assert.AreEqual(res.Url, site.Url);
        }

        [TestMethod]
        public void GetCount_test()
        {
            List<SiteDTO> mockResult = new List<SiteDTO>();
            SiteDTO siteOne = new SiteDTO() { Id = 1, RequestIp = "10.0.0.4", Url = "www.google.com/sitemap.xml" };
            SiteDTO siteTwo = new SiteDTO() { Id = 2, RequestIp = "10.0.0.4", Url = "www.google.com/sitemap.xml" };
            mockResult.Add(siteOne);
            mockResult.Add(siteTwo);
            var repo = new EFUnitOfWork();
            var siteService = new Mock<SiteService>(repo);
            siteService.Setup(t => t.GetSites()).Returns(mockResult);
            var res = siteService.Object.GetSites();
            int count = 0;
            foreach(var b in res)
            {
                count++;
            }

            Assert.IsNotNull(res);
            Assert.AreEqual(count, 2);
        }
    }
}
