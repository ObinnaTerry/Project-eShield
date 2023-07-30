using eShield.CoreData.Entities;

namespace eShield.CoreData.Interfaces
{
    public interface INetworkInfoRepo : IGenericRepo<NetworkInfo>
    {
        void Save();
    }
}