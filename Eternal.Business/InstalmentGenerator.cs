using Eternal.Models;

namespace Eternal.Business
{
    public static class InstalmentGenerator
    {
        public static List<Instalment> Generate(Contract? contract)
        {
            var list = new List<Instalment>();
            if (contract is null)
            {
                return list;
            }

            var numberOfInstalments = InstalmentPropertiesCalculator
                .CalculateNumberOfInstalments(contract.Expiration);

            var instalmentValue = InstalmentPropertiesCalculator
                .CalculateInstalmentValue(contract.Value, numberOfInstalments);

            for (int i = 0; i < numberOfInstalments; i++)
            {
                var instalment = new Instalment();
                instalment.ContractId = contract.Id;
                instalment.Value = instalmentValue;
                instalment.Expiration = DateTime.Now.AddMonths(i + 1);
                list.Add(instalment);
            }

            return list;
        }

    }
}