using System.Linq;

namespace UnitOfWorkApp.Domain.Abstract
{
    public interface IRepository<T>
    {
        //Generic methods for all Repositories, implemented in Concreate EFRepository
        IQueryable<T> GetAll();
        T GetEntity(int id);
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        T DeleteEntity(int id);
    }
}