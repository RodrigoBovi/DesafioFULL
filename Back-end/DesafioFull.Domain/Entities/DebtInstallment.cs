using System;

namespace DesafioFull.Domain.Entities
{
    public class DebtInstallment
    {
        public int DebtInstallmentId { get; set; }

        public DateTime DueDate { get; set; }

        public decimal InstallmentAmount { get; set; }

        public int DebtSecurityId { get; set; }

        public virtual DebtSecurity DebtSecurity { get; set; }
    }
}
