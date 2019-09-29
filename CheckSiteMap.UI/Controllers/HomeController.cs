using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using CheckSitemap.BLL.DTO;
using CheckSitemap.BLL.Interfaces;
using CheckSiteMap.UI.Models;
using PagedList;
using PagedList.Mvc;

namespace CheckSiteMap.UI.Controllers
{
    public class HomeController : Controller
    {
        private ISiteService _siteService;
        public HomeController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SiteViewModel siteViewModel)
        {
            if (ModelState.IsValid)
            {
                _siteService.CreateSite(siteViewModel.Url);
                return RedirectToAction("CheckRequest", new { id = _siteService.GetCount() });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult LastRequest()
        {
            return RedirectToAction("CheckRequest", new { id = _siteService.GetCount() });
        }

        [HttpGet]
        public ViewResult CheckRequest(int id)
        {
            if (ModelState.IsValid)
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

                var slowResult = (from b in siteVM.RequestsVM select new { Time = b.TimeRequest, Url = b.SitemapUrl }).Where(t => t.Time == siteVM.RequestsVM.Max(y => y.TimeRequest)).First();
                var fastResult = (from b in siteVM.RequestsVM select new { Time = b.TimeRequest, Url = b.SitemapUrl }).Where(t => t.Time == siteVM.RequestsVM.Min(y => y.TimeRequest)).First();
                ViewBag.Slow = slowResult.Url + " - " + slowResult.Time;
                ViewBag.Fast = fastResult.Url + " - " + fastResult.Time;
                ViewBag.DataPoints = JsonConvert.SerializeObject(siteVM.RequestsVM.OrderBy(p => p.TimeRequest));

                return View(siteVM);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult AllRequests(int? page)
        {
            if (ModelState.IsValid)
            {
                int size = 20;
                int pageNumber = (page ?? 1);
                IEnumerable<SiteDTO> sites = _siteService.GetSites();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SiteDTO, SiteViewModel>()).CreateMapper();
                var temp = mapper.Map<IEnumerable<SiteDTO>, IEnumerable<SiteViewModel>>(sites);
                ViewBag.PaggedList = temp.ToPagedList(pageNumber, size);
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult UserResults(int? page)
        {
            if (ModelState.IsValid)
            {
                int size = 20;
                int pageNumber = (page ?? 1);
                var sites = _siteService.GetSites();
                IEnumerable<SiteDTO> userSites = sites.Where(t => t.RequestIp == Request.UserHostAddress).ToList();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SiteDTO, SiteViewModel>()).CreateMapper();
                var temp = mapper.Map<IEnumerable<SiteDTO>, IEnumerable<SiteViewModel>>(userSites);
                ViewBag.PaggedList = temp.ToPagedList(pageNumber, size);
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult DeleteRequest(SiteViewModel siteViewModel)
        {
            _siteService.DeleteSite(siteViewModel.Id);
            return RedirectToAction("UserResults");
        }
    }
}