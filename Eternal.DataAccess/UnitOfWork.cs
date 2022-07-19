namespace Eternal.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetRepository<T>()
        {
            var output = _serviceProvider.GetService(typeof(T));
            if (output is null)
            {
                throw new NullReferenceException("This service was not provided");
            }

            return (T)output;
        }
    }
}