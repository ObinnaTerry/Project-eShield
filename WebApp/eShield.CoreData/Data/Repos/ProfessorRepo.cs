using eShield.CoreData.Data.eShield;
using eShield.CoreData.Entities;
using eShield.CoreData.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public override async Task<Professor?> GetByIDAsync(int id)
        {
            return await _context.Professors
                .Where(x => x.Id == id)
                .Include(x => x.Course)
                .Include(_ => _.Exams)
                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
