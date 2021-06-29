using DesafioFull.Domain.Entities;
using DesafioFull.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DesafioFull.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<DebtInstallment> DebtInstallments { get; set; }

        public DbSet<DebtSecurity> DebtSecuritys { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DebtSecurityMap());
            modelBuilder.ApplyConfiguration(new DebtInstallmentMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
