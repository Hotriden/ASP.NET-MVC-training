using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckSiteMap.UI.Controllers;
using System.Web.Mvc;
using CheckSitemap.BLL.Interfaces;
using CheckSitemap.BLL.Services;
using CheckSitemap.DAL.Interfaces;
using CheckSitemap.DAL.Repositories;
using Moq;
using CheckSitemap.BLL.DTO;
using CheckSiteMap.UI.Models;

namespace CheckSitemap.Test.UI
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void CheckRequest_GetSite_looking_for_first_site()
        {
            int findId = 1;
            var mockSiteService = new Mock<ISiteService>();
            mockSiteService.Setup(a => a.GetSite(findId)).Returns(new SiteDTO());
            HomeController controller = new HomeController(mockSiteService.Object);

            ViewResult result = controller.CheckRequest(findId) as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Index_simple_test()
        {
            var mockSiteService = new Mock<ISiteService>();
            HomeController controller = new HomeController(mockSiteService.Object);
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CheckRequest_GetSite_looking_for_site_by_ID()
        {
            int id = 12;
            SiteDTO siteDTO = new SiteDTO { Id = id };
            var mockSiteService = new Mock<ISiteService>();
            mockSiteService.Setup(t => t.GetSite(id)).Returns(siteDTO);

            var result = mockSiteService.Object.GetSite(12);

            Assert.AreEqual(siteDTO, result);
        }

        [TestMethod]
        public void Controllers_test_routes_to_checkrequest()
        {
            var mockSiteService = new Mock<ISiteService>();
            HomeController controller = new HomeController(mockSiteService.Object);
            ActionResult result = controller.LastRequest();
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "CheckRequest");
        }

        [TestMethod]
        public void Controllers_test_routes_to_checkrequest_second()
        {
            var mockSiteService = new Mock<ISiteService>();
            HomeController controller = new HomeController(mockSiteService.Object);
            SiteViewModel site = new SiteViewModel();
            ActionResult result = controller.Index(site);
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }
    }
}
