using Eternal.Data;
using Eternal.Models;
using Microsoft.EntityFrameworkCore;

namespace Eternal.DataAccess
{
    public class InstalmentRepository : IInstalmentRepository
    {
        private readonly EternalDbContext _dbContext;

        public InstalmentRepository(EternalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Instalment>> GetByContractIdAsync(int id)
        {
            var list = await _dbContext.Set<Instalment>()
                .Where(i => i.ContractId == id)
                .Include(i => i.Contract)
                    .ThenInclude(c => c.Client)
                .ToListAsync();

            return list;
        }
    }
}
