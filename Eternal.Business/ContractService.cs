using Eternal.DataAccess;
using Eternal.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Eternal.Business
{
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInstalmentService _instalmentService;
        private readonly IPdfService _pdfService;

        public ContractService(IUnitOfWork unitOfWork, IInstalmentService instalmentService, IPdfService pdfService)
        {
            _unitOfWork = unitOfWork;
            _instalmentService = instalmentService;
            _pdfService = pdfService;
        }

        public async Task<ContractDetailDto?> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Contract>>();
            var contract = await repository.GetByPredicateAsync(c => c.Id == id, c => c);
            return contract?.Adapt<ContractDetailDto>();
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

        public async Task<byte[]?> GetInstalmentsPdf(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Contract>>();
            var contract = await repository.GetByPredicateAsync(
                c => c.Id == id, 
                c => c.Include(c => c.Instalments).Include(c => c.Client));

            return _pdfService.GenerateInstalmentsPdf(contract);            
        }

        public async Task<byte[]?> GetContractPdf(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Contract>>();
            var contract = await repository.GetByPredicateAsync(
                c => c.Id == id,
                c => c.Include(c => c.Client));

            return _pdfService.GenerateContractPdf(contract);
        }
    }
}