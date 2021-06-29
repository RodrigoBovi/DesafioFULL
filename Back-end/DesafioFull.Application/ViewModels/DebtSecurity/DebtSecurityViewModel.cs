using DesafioFull.Application.ViewModels.DebtInstallment;
using System.Collections.Generic;

namespace DesafioFull.Application.ViewModels.DebtSecurity
{
    public class DebtSecurityViewModel
    {
        public string DebtorName { get; set; }

        public string DebtorCPF { get; set; }

        public decimal InterestPercent { get; set; }

        public decimal PenaltyPercent { get; set; }

        public virtual List<DebtInstallmentViewModel> DebtInstallments { get; set; }

        public int UserId { get; set; }
    }
}
