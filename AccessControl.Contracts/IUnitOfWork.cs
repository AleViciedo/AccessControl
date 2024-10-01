using AccessControl.Domain;

namespace Contracts
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
