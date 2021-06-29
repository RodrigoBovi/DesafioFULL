using DesafioFull.CrossCutting.Security;
using DesafioFull.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFull.Infra.Data.Mappings
{
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USER");

            builder.HasKey(p => p.UserId);

            builder
                .Property(p => p.Email)
                .HasColumnName("EMAIL")
                .IsRequired();

            builder
                .Property(p => p.Password)
                .HasColumnName("PASSWORD")
                .IsRequired();

            builder
                .Property(p => p.Username)
                .HasColumnName("USERNAME")
                .IsRequired();

            Seed(builder, Cryptography.Hash("admin"));
        }

        private void Seed(EntityTypeBuilder<User> builder, string hash)
        {
            builder.HasData(
                new User
                {
                    UserId = 1,
                    Email = "admin@desafio.com.br",
                    Password = hash,
                    Username = "admin"
                }
            );
        }
    }
}
