using DesafioFull.Domain.Entities;
using DesafioFull.Infra.Data.Context;

namespace DesafioFull.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User, int>
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
