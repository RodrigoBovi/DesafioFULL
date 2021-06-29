using DesafioFull.Domain.Entities;
using DesafioFull.Infra.Data.Context;

namespace DesafioFull.Infra.Data.Repositories
{
    public class DebtInstallmentRepository : RepositoryBase<DebtInstallment, int>
    {
        public DebtInstallmentRepository(AppDbContext context) : base(context)
        {

        }
    }
}
