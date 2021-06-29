namespace DesafioFull.CrossCutting.Validations
{
    public static class CalculateDebts
    {
        public static decimal Calculate(decimal originalValue, decimal penaltyPercent, decimal interestPercentMonth, int daysOverdue, decimal installmentAmount)
        {
            decimal penaltyValue = CalculatePenaltyPercent(originalValue, penaltyPercent); 
            decimal interestValue = CalculateInterestPercentMonth(interestPercentMonth, daysOverdue, installmentAmount);

            return originalValue + penaltyValue + interestValue;
        }

        private static decimal CalculatePenaltyPercent(decimal originalValue, decimal penaltyPercent)
        {
            return originalValue * penaltyPercent;            
        }

        private static decimal CalculateInterestPercentMonth(decimal interestPercent, int daysOverdue, decimal installmentAmount)
        {
            int monthDays = 30;

            return (interestPercent / monthDays) * daysOverdue * installmentAmount;
        }
    }
}
