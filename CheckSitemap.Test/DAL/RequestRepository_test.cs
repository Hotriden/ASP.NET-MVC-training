using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using CheckSitemap.DAL;
using CheckSitemap.DAL.Interfaces;
using CheckSitemap.DAL.Repositories;
using CheckSitemap.DAL.Entities;
using CheckSitemap.BLL.Interfaces;
using CheckSitemap.BLL.DTO;
using CheckSiteMap.UI.Controllers;

namespace CheckSitemap.Test.DAL
{
    [TestClass]
    public class RequestRepository_test
    {
        [TestMethod]
        public void GetAll_test()
        {
            var mockRequest = new Mock<IRequestService>();
            var mockSite = new Mock<ISiteService>();
            mockRequest.Setup(t => t.GetRequests(site)).Returns(new List<RequestDTO>());
            mockSite.Setup(t => t.GetSites()).Returns(new List<SiteDTO>());

            HomeController controller = new HomeController(mockSite.Object, mockRequest.Object);

            Assert.IsNotNull(controller.ModelState);
        }

        SiteDTO site = new SiteDTO() { Id = 1, RequestIp = "10.0.0.4", Url = "google.com" };

        public IEnumerable<Request> Requests()
        {
            yield return new Request() { Id = 1, SitemapUrl = "site1" };
        }
    }
}
