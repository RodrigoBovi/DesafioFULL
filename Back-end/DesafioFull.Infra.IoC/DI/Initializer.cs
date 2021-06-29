using DesafioFull.Application.Services;
using DesafioFull.Domain.Entities;
using DesafioFull.Domain.Interfaces.Repositories;
using DesafioFull.Infra.Data.Context;
using DesafioFull.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioFull.Infra.IoC.DI
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            ///Database
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conection));

            ///Repositories
            services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
            services.AddScoped(typeof(IRepositoryBase<User, int>), typeof(UserRepository));
            services.AddScoped(typeof(IRepositoryBase<DebtSecurity, int>), typeof(DebtSecurityRepository));

            ///Services
            services.AddScoped(typeof(UserService));
            services.AddScoped(typeof(DebtSecurityService));
        }
    }
}
