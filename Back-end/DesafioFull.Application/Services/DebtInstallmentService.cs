using DesafioFull.Application.ViewModels.DebtInstallment;
using DesafioFull.Domain.Entities;
using DesafioFull.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFull.Application.Services
{
    public class DebtInstallmentService
    {
        private readonly IRepositoryBase<DebtInstallment, int> _debtInstallmentRepository;

        public DebtInstallmentService(
            IRepositoryBase<DebtInstallment, int> debtInstallmentRepository
            )
        {
            _debtInstallmentRepository = debtInstallmentRepository;
        }

        public async Task<List<DebtInstallment>> GetDebtInstallmentsByDebtSecutiryId(int debtSecurityId)
        {
            try
            {
                IEnumerable<DebtInstallment> debtInstallments =  await _debtInstallmentRepository.GetAllByConditionAsync(w => w.DebtSecurityId == debtSecurityId);
                return debtInstallments.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DebtInstallment>> CreateDebtInstallments(List<DebtInstallmentViewModel> debtInstallmentsViewModel, int debtSecurityId)
        {
            try
            {
                List<DebtInstallment> debtInstallments = new List<DebtInstallment>();

                foreach (DebtInstallmentViewModel item in debtInstallmentsViewModel)
                {
                    DebtInstallment debtInstallment = new DebtInstallment
                    {
                        DueDate = item.DueDate,
                        InstallmentAmount = item.InstallmentAmount,
                        DebtSecurityId = debtSecurityId
                    };

                    debtInstallments.Add(debtInstallment);

                    await InsertDebtInstallment(debtInstallment);
                }

                return debtInstallments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task InsertDebtInstallment(DebtInstallment debtSecurity)
        {
            try
            {
                await _debtInstallmentRepository.InsertAsync(debtSecurity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
