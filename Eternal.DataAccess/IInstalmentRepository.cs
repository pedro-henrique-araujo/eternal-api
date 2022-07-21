using Eternal.Models;

namespace Eternal.DataAccess
{
    public interface IInstalmentRepository
    {
        Task<List<Instalment>> GetByContractIdAsync(int id);
    }
}
