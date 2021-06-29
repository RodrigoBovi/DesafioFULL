using DesafioFull.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFull.Infra.Data.Mappings
{
    class DebtInstallmentMap : IEntityTypeConfiguration<DebtInstallment>
    {
        public void Configure(EntityTypeBuilder<DebtInstallment> builder)
        {
            builder.ToTable("TB_DEBT_INSTALLMENT");

            builder.HasKey(p => p.DebtInstallmentId);

            builder
                .Property(p => p.DueDate)
                .HasColumnName("DUE_DATE")
                .IsRequired();

            builder
                .Property(p => p.InstallmentAmount)
                .HasColumnName("INSTALLMENT_AMOUNT")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .HasOne(p => p.DebtSecurity)
                .WithMany(p => p.DebtInstallments)
                .HasForeignKey(p => p.DebtSecurityId);
        }
    }
}
