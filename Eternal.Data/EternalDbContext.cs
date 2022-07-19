using Eternal.Models;
using Microsoft.EntityFrameworkCore;

namespace Eternal.Data
{
    public class EternalDbContext : DbContext
    {
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Contract>? Contracts { get; set; }
        public DbSet<Instalment>? Instalments { get; set; }
    }
}