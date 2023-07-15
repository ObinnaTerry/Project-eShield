using eShield.CoreData.Entities;

namespace eShield.CoreData.Interfaces
{
    public interface IProxyDataRepo : IGenericRepo<VisitedSite>
    {
        void Save();
    }
}