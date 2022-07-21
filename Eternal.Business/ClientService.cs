using Eternal.DataAccess;
using Eternal.Models;
using Mapster;

namespace Eternal.Business
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientDetailDto?> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Client>>();
            var client = (await repository.GetByIdAsync(id))?.Adapt<ClientDetailDto>();
            return client;
        }

        public async Task<Pagination<ClientPaginationDto>> GetPaginationAsync(
            int? page = null,
            string? search = null)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Client>>();
            var pagination = await repository.GetPaginationAsync(
                page,
                SearchExpressionGenerator.ForClient(search));

            return pagination.Adapt<Pagination<ClientPaginationDto>>();
        }

        public async Task<ClientDetailDto?> CreateAsync(ClientCreationDto creatinglDto)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Client>>();
            var entity = await repository.CreateAsync(creatinglDto.Adapt<Client>());
            return entity?.Adapt<ClientDetailDto>();
        }

        public async Task<ClientDetailDto?> UpdateAsync(ClientUpdatingDto updatingDto)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Client>>();
            var entity = await repository.UpdateAsync(updatingDto.Adapt<Client>());
            return entity?.Adapt<ClientDetailDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Client>>();
            await repository.DeleteAsync(id);
        }

        public async Task<List<ClientOptionDto>> GetOptionsAsync()
        {
            var repository = _unitOfWork.GetRepository<IRepository<Client>>();
            var list = await repository.GetAllAsync(c => new ClientOptionDto 
            {  
                Id = c.Id, 
                Name = c.Name 
            });
            return list;
        }
    }
}