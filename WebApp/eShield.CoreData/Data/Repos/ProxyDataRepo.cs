using eShield.CoreData.Data.eShield;
using eShield.CoreData.Entities;
using eShield.CoreData.Interfaces;

namespace eShield.CoreData.Data.Repos
{
    public class ProxyDataRepo : GenericRepo<VisitedSite>, IDisposable, IProxyDataRepo
    {
        private readonly EShieldContext _context;

        public ProxyDataRepo(EShieldContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
