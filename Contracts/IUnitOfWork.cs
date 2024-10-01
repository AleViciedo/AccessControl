using AccessControl.Domain;

namespace AccessControl.Contracts
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
