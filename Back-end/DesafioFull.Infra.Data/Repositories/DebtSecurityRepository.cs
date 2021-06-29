using DesafioFull.Domain.Entities;
using DesafioFull.Infra.Data.Context;
using System.Threading.Tasks;

namespace DesafioFull.Infra.Data.Repositories
{
    public class DebtSecurityRepository : RepositoryBase<DebtSecurity, int>
    {
        public DebtSecurityRepository(AppDbContext context) : base(context)
        {

        }
    }
}
