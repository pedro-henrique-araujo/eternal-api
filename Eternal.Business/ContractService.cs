using Eternal.DataAccess;
using Eternal.Models;
using Mapster;

namespace Eternal.Business
{
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInstalmentService _instalmentService;

        public ContractService(IUnitOfWork unitOfWork, IInstalmentService instalmentService)
        {
            _unitOfWork = unitOfWork;
            _instalmentService = instalmentService;
        }

        public async Task<ContractDetailDto?> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Contract>>();
            var contract = (await repository.GetByIdAsync(id))?.Adapt<ContractDetailDto>();
            return contract;
        }

        public async Task<Pagination<ContractPaginationDto>> GetPaginationAsync(
            int? page = null,
            string? search = null)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Contract>>();
            var pagination = await repository.GetPaginationAsync(
                page,
                SearchExpressionGenerator.ForContract(search));

            return pagination.Adapt<Pagination<ContractPaginationDto>>();
        }

        public async Task<ContractDetailDto?> CreateAsync(ContractCreationDto creatinglDto)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Contract>>();
            var entity = await repository.CreateAsync(creatinglDto.Adapt<Contract>());
            return entity?.Adapt<ContractDetailDto>();
        }

        public async Task<ContractDetailDto?> UpdateAsync(ContractUpdatingDto updatingDto)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Contract>>();
            var entity = await repository.UpdateAsync(updatingDto.Adapt<Contract>());
            return entity?.Adapt<ContractDetailDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Contract>>();
            await repository.DeleteAsync(id);
        }

        public async Task ProcessAsync(int id)
        {
            await _instalmentService.GenerateForAsync(id);            
        }
    }
}