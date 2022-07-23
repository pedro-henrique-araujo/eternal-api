using Eternal.Models;

namespace Eternal.Business
{
    public interface IPdfService
    {
        byte[]? GenerateInstalmentsPdf(ContractDetailDto contract);
    }
}
