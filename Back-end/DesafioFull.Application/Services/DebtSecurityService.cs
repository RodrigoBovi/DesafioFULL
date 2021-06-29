using DesafioFull.Application.ViewModels.DebtSecurity;
using DesafioFull.Domain.Entities;
using DesafioFull.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace DesafioFull.Application.Services
{
    public class DebtSecurityService
    {
        private readonly IRepositoryBase<DebtSecurity, int> _debtSecurityRepository;

        public DebtSecurityService(
            IRepositoryBase<DebtSecurity, int> debtSecurityRepository
            )
        {
            _debtSecurityRepository = debtSecurityRepository;
        }

        public async Task<DebtSecurityResponseViewModel> CreateDebtSecurity(DebtSecurityViewModel debtSecurityViewModel)
        {
            try
            {
                DebtSecurityResponseViewModel debtSecurityResponse = new DebtSecurityResponseViewModel();

                return debtSecurityResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
