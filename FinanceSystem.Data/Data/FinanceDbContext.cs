using FinanceSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceSystem.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {
        }

        public DbSet<NotaFiscal> NotasFiscais { get; set; }
    }
}
