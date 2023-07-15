using eShield.CoreData.Entities;

namespace eShield.CoreData.Interfaces
{
    public interface IStudentRepo : IGenericRepo<Student>
    {
        void Save();
    }
}