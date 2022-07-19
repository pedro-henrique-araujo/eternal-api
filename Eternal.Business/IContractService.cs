using Eternal.Models;

namespace Eternal.Business
{
    public interface IContractService
    {
        Task<ContractDetailDto?> CreateAsync(ContractCreationDto creatinglDto);
        Task DeleteAsync(int id);
        Task<ContractDetailDto?> GetByIdAsync(int id);
        Task<Pagination<ContractPaginationDto>> GetPaginationAsync(int? page = null, string? search = null);
        Task<ContractDetailDto?> UpdateAsync(ContractUpdatingDto updatingDto);
        Task ProcessAsync(int id);
    }
}