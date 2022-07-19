using Eternal.Models;

namespace Eternal.Business
{
    public interface IClientService
    {
        Task<ClientDetailDto?> CreateAsync(ClientCreationDto creatinglDto);
        Task DeleteAsync(int id);
        Task<ClientDetailDto?> GetByIdAsync(int id);
        Task<Pagination<ClientPaginationDto>> GetPaginationAsync(int? page = null, string? search = null);
        Task<ClientDetailDto?> UpdateAsync(ClientUpdatingDto updatingDto);

        Task<List<ClientOptionDto>> GetOptionsAsync();
    }
}