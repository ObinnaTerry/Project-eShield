using eShield.CoreData.Entities;
using eShield.CoreData.Interfaces;
using eShield_API.DTOs;

namespace eShield_API.DataService
{
    public class ProxyDataService
    {
        private readonly IProxyDataRepo _proxyDataRepo;

        public ProxyDataService(IProxyDataRepo proxyDataRepo)
        {
            _proxyDataRepo = proxyDataRepo;
        }

        public List<VisitedSiteDTO> Get(int id)
        {
            List<VisitedSiteDTO> visitedSites = new List<VisitedSiteDTO>();

            IQueryable<VisitedSite> result = _proxyDataRepo.GetAll().Where(x => x.Id == id).GroupBy(x => x.StudentId)
                .Select(group => group.OrderByDescending(site => site.CreateTime).First());

            foreach (var record in result)
            {
                visitedSites.Add(new VisitedSiteDTO(record.Id, record.StudentId, record.ExamId, record.Website, record.CreateTime));
            }

            return visitedSites;
        }

        public void Post(VisitedSiteDTO visitedSite)
        {
            VisitedSite site = new VisitedSite();

            site.Id = visitedSite.Id;
            site.StudentId = visitedSite.StudentId;
            site.Website = visitedSite.Website;
            site.CreateTime = visitedSite.CreateTime;
            site.ExamId = visitedSite.ExamId;

            _proxyDataRepo.Insert(site);
            _proxyDataRepo.Save();
        }
    }
}
