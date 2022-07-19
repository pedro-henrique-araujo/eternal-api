using Eternal.DataAccess;
using Eternal.Models;
using Mapster;

namespace Eternal.Business
{
    public class InstalmentService : IInstalmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstalmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task GenerateForAsync(int id)
        {
            var contractRepository = _unitOfWork.GetRepository<IRepository<Contract>>();
            var contract = await contractRepository.GetByIdAsync(id);

            var instalments = InstalmentGenerator.Generate(contract);

            await _unitOfWork.GetRepository<IRepository<Instalment>>().CreateRangeAsync(instalments);
        }

        public async Task<List<InstalmentDetailDto>> GetForPrintAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<IInstalmentRepository>();
            var list = await repository.GetByContractIdAsync(id);
            return list.Adapt<List<InstalmentDetailDto>>();
        }
    }
}
