using JobMaster.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobMaster
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbContext;
        // Track whether Dispose has been called.
        private bool disposed = false;

    
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    _dbContext.Dispose();
                }

              
                // Note disposing has been done.
                disposed = true;

            }
        }



    
        //public async Task Delete<T>() where T : class
        //{
        //    throw new NotImplementedException();
        //}

        public IQueryable<T> GetAll<T>() where T : class
        {
            DbSet<T> entities = _dbContext.Set<T>();

            return entities;
        }

        public void Add<T>(T entity) where T : class
        {
            DbSet<T> entities = _dbContext.Set<T>();
            entities.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        //public void Save()
        //{
        //    _dbContext.SaveChanges();
        //}

        //public async Task Update<T>() where T : class
        //{
        //    throw new NotImplementedException();
        //}
    }
}
