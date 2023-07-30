using eShield.CoreData.Entities;

namespace eShield.CoreData.Interfaces
{
    public interface IExamRepo : IGenericRepo<Exam>
    {
        void Save();
    }
}