using Eternal.Models;

namespace Eternal.Business
{
    public interface IPdfService
    {
        byte[]? GenerateInstalmentsPdf(Contract contract);
        byte[]? GenerateContractPdf(Contract contract);
    }
}
