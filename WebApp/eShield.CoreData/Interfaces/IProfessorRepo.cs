using eShield.CoreData.Entities;

namespace eShield.CoreData.Interfaces
{
    public interface IProfessorRepo : IGenericRepo<Professor>
    {
        Task<Professor?> GetByIDAsync(int id);
        void Save();
    }
}