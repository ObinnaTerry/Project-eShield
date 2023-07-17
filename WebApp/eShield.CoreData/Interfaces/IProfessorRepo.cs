using eShield.CoreData.Entities;

namespace eShield.CoreData.Interfaces
{
    public interface IProfessorRepo : IGenericRepo<Professor>
    {
        void Save();
    }
}