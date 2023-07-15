namespace eShield.CoreData.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        void Delete(object id);
        void Delete(T? entityToDelete);
        IQueryable<T> GetAll();
        Task<T?> GetByIDAsync(int? id);
        void Insert(T entity);
        void Update(T entityToUpdate);
    }
}