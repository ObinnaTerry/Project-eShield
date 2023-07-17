using eShield.CoreData.Data.Repos;
using eShield.CoreData.Entities;
using eShield.CoreData.Interfaces;
using eShield_API.DTOs;

namespace eShield_API.DataService
{
    public class ProxyDataService
    {
        private readonly IProxyDataRepo _proxyDataRepo;
        private readonly INetworkInfoRepo _networkInfoRepo;

        public ProxyDataService(IProxyDataRepo proxyDataRepo, INetworkInfoRepo networkInfoRepo)
        {
            _proxyDataRepo = proxyDataRepo;
            _networkInfoRepo = networkInfoRepo;
        }

        public List<VisitedSiteDashboardDTO> Get(int id)
        {
            //TODO: Potential issue for users with only 1 record. this will cuz the second most recent record to return null
            // which will break the code. needs to handle this situation correctly

            List<VisitedSiteDashboardDTO> visitedSites = new List<VisitedSiteDashboardDTO>();

            List<VisitedSite> mostRecent = _proxyDataRepo.GetAll()
                .Where(x => x.ExamId == id)
                .GroupBy(x => x.StudentId)
                .Select(group => group.OrderByDescending(site => site.CreateTime).First()).ToList();

            var nextRecent = _proxyDataRepo.GetAll()
            .Where(x => x.ExamId == id)
            .GroupBy(x => x.StudentId)
            .Select(group => group.OrderByDescending(site => site.CreateTime).Skip(1).Take(1))
            .SelectMany(inner => inner).ToList();

            foreach (var latest in mostRecent)
            {
                var secondLatest = nextRecent.Where(x => x.StudentId == latest.StudentId).FirstOrDefault();

                VisitedSiteDashboardDTO visitedSiteDTO = new VisitedSiteDashboardDTO 
                {
                    Id = latest.Id,
                    FirstName = latest.Student.FirstName,
                    LastName = latest.Student.LastName,
                    Email = latest.Student.Email,
                    Timelapse = (latest.CreateTime - secondLatest!.CreateTime).TotalSeconds
                };

                visitedSites.Add(visitedSiteDTO);
            }

            return visitedSites;
        }

        public void Post(VisitedSiteDTO visitedSite, string? IPAdress)
        {
            VisitedSite site = new VisitedSite();

            NetworkInfo? networkInfo = _networkInfoRepo.GetAll().Where(x => x.Ipaddress == IPAdress).FirstOrDefault();

            site.StudentId = networkInfo!.StudentId;
            site.Website = visitedSite.WebSite!;
            site.CreateTime = visitedSite.CreateTime;
            site.ExamId = networkInfo.ExamId;
            site.Macaddress = networkInfo.Macaddress;

            _proxyDataRepo.Insert(site);
            _proxyDataRepo.Save();
        }
    }
}
