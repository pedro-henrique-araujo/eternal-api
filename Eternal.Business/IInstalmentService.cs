using Eternal.Models;

namespace Eternal.Business
{
    public interface IInstalmentService
    {
        Task GenerateForAsync(int id);

        Task<List<InstalmentDetailDto>> GetForPrintAsync(int id);
    }
}
