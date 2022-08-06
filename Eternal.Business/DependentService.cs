using Eternal.DataAccess;
using Eternal.Models;
using Mapster;

namespace Eternal.Business
{
    public class DependentService : IDependentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DependentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DependentDetailDto?> CreateAsync(DependentCreationDto creationDto)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Dependent>>();
            var entity = await repository.CreateAsync(creationDto.Adapt<Dependent>());
            return entity?.Adapt<DependentDetailDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Dependent>>();
            await repository.DeleteAsync(id);
        }

        public async Task<List<DependentDetailDto>?> GetByClientIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Dependent>>();
            var list = await repository.GetListAsync(d => d.ClientId == id);
            return list?.Adapt<List<DependentDetailDto>>();
        }

        public async Task<DependentDetailDto?> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Dependent>>();
            var dependent = (await repository.GetByIdAsync(id))?.Adapt<DependentDetailDto>();
            return dependent;
        }

        public async Task<List<DependentOptionDto>?> GetOptionsAsync()
        {
            var repository = _unitOfWork.GetRepository<IRepository<Dependent>>();
            var list = await repository.GetListAsync(c => new DependentOptionDto
            {
                Id = c.Id,
                Name = c.Name
            });

            return list;
        }

        public async Task<DependentDetailDto?> UpdateAsync(DependentUpdatingDto updatingDto)
        {
            var repository = _unitOfWork.GetRepository<IRepository<Dependent>>();
            var entity = await repository.UpdateAsync(updatingDto.Adapt<Dependent>());
            return entity?.Adapt<DependentDetailDto>();
        }
    }
}
