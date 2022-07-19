namespace Eternal.DataAccess
{
    public interface IUnitOfWork
    {
        T GetRepository<T>();
    }
}