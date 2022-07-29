using Eternal.DataAccess;
using Eternal.Models;
using Mapster;

namespace Eternal.Business
{
    public class ContractTemplateService : IContractTemplateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContractTemplateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ContractTemplateDetailDto?> CreateAsync(ContractTemplateCreationDto creatinglDto)
        {
            var repository = _unitOfWork.GetRepository<IRepository<ContractTemplate>>();
            var entity = await repository.CreateAsync(creatinglDto.Adapt<ContractTemplate>());
            return entity?.Adapt<ContractTemplateDetailDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<ContractTemplate>>();
            await repository.DeleteAsync(id);
        }

        public async Task<ContractTemplateDetailDto?> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<ContractTemplate>>();
            var template = (await repository.GetByIdAsync(id))?.Adapt<ContractTemplateDetailDto>();
            return template;
        }

        public async Task<List<ContractTemplateOptionDto>> GetOptionsAsync()
        {
            var repository = _unitOfWork.GetRepository<IRepository<ContractTemplate>>();
            var list = await repository.GetListAsync(c => new ContractTemplateOptionDto
            {
                Id = c.Id,
                Name = c.Name
            });
            return list;
        }

        public async Task<Pagination<ContractTemplatePaginationDto>> GetPaginationAsync(int? page = null, string? search = null)
        {
            var repository = _unitOfWork.GetRepository<IRepository<ContractTemplate>>();
            var pagination = await repository.GetPaginationAsync(
                page,
                SearchExpressionGenerator.ForContractTemplate(search));

            return pagination.Adapt<Pagination<ContractTemplatePaginationDto>>();
        }

        public async Task<ContractTemplateDetailDto?> UpdateAsync(ContractTemplateUpdatingDto updatingDto)
        {
            var repository = _unitOfWork.GetRepository<IRepository<ContractTemplate>>();
            var entity = await repository.UpdateAsync(updatingDto.Adapt<ContractTemplate>());
            return entity?.Adapt<ContractTemplateDetailDto>();
        }
    }
}
