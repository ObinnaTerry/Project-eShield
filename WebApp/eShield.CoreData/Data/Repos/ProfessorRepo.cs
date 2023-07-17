using eShield.CoreData.Data.eShield;
using eShield.CoreData.Entities;
using eShield.CoreData.Interfaces;

namespace eShield.CoreData.Data.Repos
{
    public class ProfessorRepo : GenericRepo<Professor>, IDisposable, IProfessorRepo
    {
        private readonly EShieldContext _context;
        private bool disposed;

        public ProfessorRepo(EShieldContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
