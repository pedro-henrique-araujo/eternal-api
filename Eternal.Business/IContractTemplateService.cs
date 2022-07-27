using Eternal.Models;

namespace Eternal.Business
{
    public interface IContractTemplateService
    {
        Task<ContractTemplateDetailDto?> CreateAsync(ContractTemplateCreationDto creatinglDto);
        Task DeleteAsync(int id);
        Task<ContractTemplateDetailDto?> GetByIdAsync(int id);
        Task<Pagination<ContractTemplatePaginationDto>> GetPaginationAsync(int? page = null, string? search = null);
        Task<ContractTemplateDetailDto?> UpdateAsync(ContractTemplateUpdatingDto updatingDto);

        Task<List<ContractTemplateOptionDto>> GetOptionsAsync();
    }
}
