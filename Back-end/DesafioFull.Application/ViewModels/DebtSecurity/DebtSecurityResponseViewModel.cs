namespace DesafioFull.Application.ViewModels.DebtSecurity
{
    public class DebtSecurityResponseViewModel
    {
        public int DebtSecurityId { get; set; }

        public string DebtorName { get; set; }

        public int NumberInstallments { get; set; }

        public decimal OriginalValue { get; set; }

        public int DaysOverdue { get; set; }

        public decimal UpdatedAmount { get; set; }
    }
}
