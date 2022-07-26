using Eternal.Models;

namespace Eternal.Business
{
    public interface IInstalmentService
    {
        Task GenerateForAsync(int id);

        Task<List<InstalmentDetailDto>> GetByContractAsync(int id);

        Task<InstalmentDetailDto> GetByIdAsync(int id);

        Task<InstalmentDetailDto> PayByIdAsync(int id);
    }
}
