using UnitOfWorkApp.Domain.Concrete;

namespace UnitOfWorkApp.Domain.Abstract
{
    public interface IEFUnitOfWork
    {
        EFDbContext Context { get; }
    }
}