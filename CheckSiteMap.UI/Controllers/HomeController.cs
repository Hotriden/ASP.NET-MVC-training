using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using CheckSitemap.BLL.DTO;
using CheckSitemap.BLL.Interfaces;
using CheckSiteMap.UI.Models;

namespace CheckSiteMap.UI.Controllers
{
    public class HomeController : Controller
    {
        private ISiteService _siteService;
        private IRequestService _requestService;
        public HomeController(ISiteService siteService, IRequestService requestService)
        {
            _siteService = siteService;
            _requestService = requestService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SiteViewModel site)
        {
            _siteService.CreateSite(site.Url);
            return RedirectToAction("CheckRequest", new { id = _siteService.GetCount()});
        }

        [HttpGet]
        public ActionResult LastRequest()
        {
            return RedirectToAction("CheckRequest", new { id = _siteService.GetCount()});
        }

        [HttpGet]
        public ViewResult CheckRequest(int id)
        {
            SiteDTO tempSite = _siteService.GetSite(id);
            var mapperVM = new MapperConfiguration(cfg => cfg.CreateMap<RequestDTO, RequestViewModel>()).CreateMapper();
            var temp = mapperVM.Map<List<RequestDTO>, List<RequestViewModel>>(tempSite.RequestsDTO);
            SiteViewModel siteVM = new SiteViewModel
            {
                Id = tempSite.Id,
                RequestIp = tempSite.RequestIp,
                SummaryTime = tempSite.SummaryTime,
                Url = tempSite.Url,
                RequestsVM = temp
            };

            ViewBag.DataPoints = JsonConvert.SerializeObject(siteVM.RequestsVM.OrderBy(p => p.TimeRequest));

            return View(siteVM);
        }

        [HttpGet]
        public ViewResult AllRequests()
        {
            IEnumerable<SiteDTO> sites = _siteService.GetSites();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SiteDTO, SiteViewModel>()).CreateMapper();
            var temp = mapper.Map<IEnumerable<SiteDTO>, IEnumerable<SiteViewModel>>(sites);
            return View(temp);
        }
    }
}