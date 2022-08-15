using Eternal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Eternal.Data
{
    public class EternalDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Client>? Clients { get; set; }
        public DbSet<Dependent>? Dependents { get; set; }
        public DbSet<Contract>? Contracts { get; set; }
        public DbSet<Instalment>? Instalments { get; set; }
        public DbSet<ContractTemplate>? ContractTemplates { get; set; }


        public EternalDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("Eternal");
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}