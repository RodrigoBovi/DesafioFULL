using System;

namespace DesafioFull.Application.ViewModels.DebtInstallment
{
    public class DebtInstallmentViewModel
    {
        public DateTime DueDate { get; set; }

        public decimal InstallmentAmount { get; set; }

        public int DebtSecurityId { get; set; }
    }
}
