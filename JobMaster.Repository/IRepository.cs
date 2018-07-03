using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobMaster
{
    public interface IRepository:IDisposable, IUnitOfWork
    {
        IQueryable<T> GetAll<T>() where T: class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        //T Get(long id);
    }
}
