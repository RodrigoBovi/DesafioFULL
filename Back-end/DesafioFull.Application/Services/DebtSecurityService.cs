using DesafioFull.Application.ViewModels.DebtInstallment;
using DesafioFull.Application.ViewModels.DebtSecurity;
using DesafioFull.CrossCutting.Validations;
using DesafioFull.Domain.Entities;
using DesafioFull.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFull.Application.Services
{
    public class DebtSecurityService
    {
        private readonly IRepositoryBase<DebtSecurity, int> _debtSecurityRepository;
        private readonly DebtInstallmentService _debtInstallmentService;

        public DebtSecurityService(
            IRepositoryBase<DebtSecurity, int> debtSecurityRepository,
            DebtInstallmentService debtInstallmentService
            )
        {
            _debtSecurityRepository = debtSecurityRepository;
            _debtInstallmentService = debtInstallmentService;
        }

        public async Task<List<DebtSecurityResponseViewModel>> GetUserDebtSecurities(int userId)
        {
            try
            {
                List<DebtSecurityResponseViewModel> debtSecuritiesResponse = new List<DebtSecurityResponseViewModel>();

                IEnumerable<DebtSecurity> debtSecurities = await _debtSecurityRepository.GetAllByConditionAsync(w => w.UserId == userId);

                foreach (DebtSecurity itemDebtSecurity in debtSecurities)
                {
                    List<DebtInstallment> debtInstallments = await _debtInstallmentService.GetDebtInstallmentsByDebtSecutiryId(itemDebtSecurity.DebtSecurityId);
                    List<DebtInstallment> debtInstallmentsExpired = debtInstallments.Where(w => w.DueDate.Date < DateTime.Now.Date).ToList();

                    DebtSecurityResponseViewModel debtSecurityResponse = new DebtSecurityResponseViewModel
                    {
                        DebtSecurityId = itemDebtSecurity.DebtSecurityId,
                        DebtorName = itemDebtSecurity.DebtorName,
                        NumberInstallments = debtInstallments.Count(),
                        OriginalValue = debtInstallments.Sum(w => w.InstallmentAmount)
                    };

                    decimal interestPercent = 0;
                    decimal penaltyValue = CalculateDebts.CalculatePenaltyPercent(debtSecurityResponse.OriginalValue, itemDebtSecurity.PenaltyPercent);

                    foreach (DebtInstallment itemDebtInstallment in debtInstallmentsExpired)
                    {
                        int daysOverdue = (DateTime.Now - itemDebtInstallment.DueDate).Days;

                        interestPercent += CalculateDebts.CalculateInterestPercent(
                            itemDebtSecurity.InterestPercent,
                            daysOverdue,
                            itemDebtInstallment.InstallmentAmount
                            );
                    }

                    debtSecurityResponse.UpdatedAmount = debtSecurityResponse.OriginalValue +  penaltyValue + interestPercent;

                    debtSecuritiesResponse.Add(debtSecurityResponse);
                }

                return debtSecuritiesResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DebtSecurityResponseViewModel>> CreateDebtSecurity(DebtSecurityViewModel debtSecurityViewModel)
        {
            try
            {
                List<DebtInstallment> debtInstallments = new List<DebtInstallment>();

                DebtSecurityResponseViewModel debtSecurityResponse = new DebtSecurityResponseViewModel();
                DebtSecurity debtSecurity = new DebtSecurity
                {
                    DebtorName = debtSecurityViewModel.DebtorName,
                    DebtorCPF = debtSecurityViewModel.DebtorCPF,
                    InterestPercent = debtSecurityViewModel.InterestPercent,
                    PenaltyPercent = debtSecurityViewModel.PenaltyPercent,
                    UserId = debtSecurityViewModel.UserId
                };

                int debtSecurityId = await InsertDebtSecurity(debtSecurity, "DebtSecurityId");

                if (debtSecurityId > 0)
                {
                    debtInstallments = await CreateDebtInstallments(debtSecurityViewModel.DebtInstallments, debtSecurityId);
                }

                return await GetUserDebtSecurities(debtSecurityViewModel.UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<List<DebtInstallment>> CreateDebtInstallments(List<DebtInstallmentViewModel> debtInstallmentsViewModel, int debtSecurityId)
        {
            try
            {
                List<DebtInstallment> debtInstallments = await _debtInstallmentService.CreateDebtInstallments(debtInstallmentsViewModel, debtSecurityId);
                return debtInstallments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<int> InsertDebtSecurity(DebtSecurity debtSecurity, string primaryKeyName)
        {
            try
            {
                return await _debtSecurityRepository.InsertReturnIntAsync(debtSecurity, primaryKeyName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
