using eShield.CoreData.Entities;

namespace eShield.CoreData.Interfaces
{
    public interface ICourseRepo : IGenericRepo<Course>
    {
        void Save();
    }
}