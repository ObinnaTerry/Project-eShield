using eShield.CoreData.Data.eShield;
using eShield.CoreData.Entities;
using eShield.CoreData.Interfaces;

namespace eShield.CoreData.Data.Repos
{

    public class CourseRepo : GenericRepo<Course>, IDisposable, ICourseRepo

        {
        private readonly EShieldContext _context;

        public CourseRepo(EShieldContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
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

