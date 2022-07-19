using Eternal.Models;

namespace Eternal.Business
{
    public interface IInstalmentRepository
    {
        Task<List<Instalment>> GetByContractIdAsync(int id);
    }
}
