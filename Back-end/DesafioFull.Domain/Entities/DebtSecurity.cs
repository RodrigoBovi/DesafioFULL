using System.Collections.Generic;

namespace DesafioFull.Domain.Entities
{
    public class DebtSecurity
    {
        public int DebtSecurityId { get; set; }

        public string DebtorName { get; set; }

        public string DebtorCPF { get; set; }

        public decimal InterestPercent { get; set; }

        public decimal PenaltyPercent { get; set; }

        public int UserId { get; set; }

        public virtual List<DebtInstallment> DebtInstallments { get; set; }

        public virtual User User { get; set; }
    }
}
