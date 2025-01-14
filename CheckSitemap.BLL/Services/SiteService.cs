﻿using CheckSitemap.BLL.DTO;
using CheckSitemap.DAL.Entities;
using CheckSitemap.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CheckSitemap.BLL.Infrastracture;
using System.Web;
using CheckSitemap.BLL.BusinessModels;
using CheckSitemap.BLL.Interfaces;

namespace CheckSitemap.BLL.Services
{
    /// <summary>
    /// ISiteService implementation on business logic layer
    /// with based functionality
    /// </summary>
    public class SiteService : ISiteService
    {
        IUnitOfWork DataBase { get; set; } 
        public SiteService(IUnitOfWork uof) // Constructor with initializing UOW class aimed on db
        {
            DataBase = uof;
        }
        public void CreateSite(string inputUrl)
        {
            List<Request> requestList = new GetSiteMap(inputUrl).requests;
            Site site = new Site
            {
                RequestIp = HttpContext.Current.Request.UserHostAddress,
                Url = inputUrl,
                Requests = requestList,
                SummaryTime = new TimeCounter(requestList).time,
                CreateTime = DateTime.Now,
                SiteAmount = requestList.Count()
            };
            DataBase.Sites.Create(site);
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public IEnumerable<SiteDTO> GetSites()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Site, SiteDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Site>, List<SiteDTO>>(DataBase.Sites.GetAll());
        }

        public SiteDTO GetSite(int id)
        {
            if (id == 0)
                throw new NotFoundException("Site URL didn't specified", "");
            var site = DataBase.Sites.Get(id);
            if (site == null)
                throw new NotFoundException("This site didn't get requests", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Request, RequestDTO>()).CreateMapper();
            List<RequestDTO> req = mapper.Map<List<Request>, List<RequestDTO>>(site.Requests);
            return new SiteDTO { Id = site.Id, Url = site.Url, RequestIp = site.RequestIp, SummaryTime = site.SummaryTime, RequestsDTO=req};
        }

        public int GetLast()
        {
            try
            {
                return DataBase.Sites.GetAll().First().Id; 
            }
            catch (Exception)
            {
                throw new NotFoundException("Sites list is empty","");
            }
        }

        public void DeleteSite(int id)
        {
            DataBase.Sites.Delete(id);
            DataBase.Save();
        }
    }
}
