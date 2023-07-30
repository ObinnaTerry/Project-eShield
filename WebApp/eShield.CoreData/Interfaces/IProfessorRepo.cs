using eShield.CoreData.Entities;

namespace eShield.CoreData.Interfaces
{
    public interface IProfessorRepo : IGenericRepo<Professor>
    {
        //IQueryable<Professor> GetAll();
        //Task<Professor?> GetByIDAsync(int? id);
        void Save();
    }
}