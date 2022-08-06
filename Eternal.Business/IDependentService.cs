using Eternal.Models;

namespace Eternal.Business
{
    public interface IDependentService
    {
        Task<List<DependentDetailDto>?> GetByClientIdAsync(int id);
        Task<DependentDetailDto?> GetByIdAsync(int id);
        Task<List<DependentOptionDto>?> GetOptionsAsync();
        Task<DependentDetailDto?> CreateAsync(DependentCreationDto creationDto);
        Task<DependentDetailDto?> UpdateAsync(DependentUpdatingDto updatingDto);
        Task DeleteAsync(int id);
    }
}
