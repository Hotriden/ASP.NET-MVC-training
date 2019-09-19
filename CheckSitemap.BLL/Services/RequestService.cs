using AutoMapper;
using CheckSitemap.BLL.DTO;
using CheckSitemap.BLL.Interfaces;
using CheckSitemap.DAL.Entities;
using CheckSitemap.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSitemap.BLL.Services
{
    public class RequestService : IRequestService
    {
        IUnitOfWork DataBase { get; set; }

        public RequestService(IUnitOfWork uow)
        {
            DataBase = uow;
        }
        public void Dispose()
        {
            DataBase.Dispose();
        }

        public IEnumerable<RequestDTO> GetRequests(SiteDTO site)
        {
            IEnumerable<Request> req = DataBase.Requests.GetById(site.Id);
            var mapperRequests = new MapperConfiguration(cfg => cfg.CreateMap<Request, RequestDTO>()).CreateMapper();
            return mapperRequests.Map<IEnumerable<Request>, List<RequestDTO>>(req);
        }
    }
}
