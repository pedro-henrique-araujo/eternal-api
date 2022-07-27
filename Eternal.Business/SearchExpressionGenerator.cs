using Eternal.Models;
using System.Linq.Expressions;

namespace Eternal.Business
{
    public static class SearchExpressionGenerator
    {
        public static Expression<Func<Client, bool>> ForClient(string? search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return c => true;
            }

            var searchLower = search.ToLower();
            return c => c.Id.ToString().Contains(searchLower)
            || (c.Name == null ? string.Empty : c.Name).ToLower().Contains(searchLower);
        }

        internal static Expression<Func<Contract, bool>>? ForContract(string? search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return c => true;
            }
            var searchLower = search.ToLower();
            return c => c.Id.ToString().Contains(searchLower);
        }

        public static Expression<Func<ContractTemplate, bool>>? ForContractTemplate(string? search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return c => true;
            }
            var searchLower = search.ToLower();
            return c => c.Id.ToString().Contains(searchLower);
        }
    }
}