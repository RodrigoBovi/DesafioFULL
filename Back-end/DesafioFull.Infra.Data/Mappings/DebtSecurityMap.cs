using DesafioFull.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFull.Infra.Data.Mappings
{
    class DebtSecurityMap : IEntityTypeConfiguration<DebtSecurity>
    {
        public void Configure(EntityTypeBuilder<DebtSecurity> builder)
        {
            builder.ToTable("TB_DEBT_SECURITY");

            builder.HasKey(p => p.DebtSecurityId);

            builder
                .Property(p => p.DebtorName)
                .HasColumnName("DEBTOR_NAME")
                .IsRequired();

            builder
                .Property(p => p.DebtorCPF)
                .HasColumnName("DEBTOR_CPF")
                .IsRequired();

            builder
                .Property(p => p.InterestPercent)
                .HasColumnName("INTEREST_PERCENT")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(p => p.PenaltyPercent)
                .HasColumnName("PENALTY_PERCENT")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.DebtSecuritys)
                .HasForeignKey(p => p.UserId);
        }
    }
}
