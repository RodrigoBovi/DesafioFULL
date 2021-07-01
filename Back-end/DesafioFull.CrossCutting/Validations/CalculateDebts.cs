using System;

namespace DesafioFull.CrossCutting.Validations
{
    public static class CalculateDebts
    {
        public static decimal CalculateInterestPercent(decimal interestPercentMonth, int daysOverdue, decimal installmentAmount)
        {
            decimal interestValue = CalculateInterestPercentMonth(interestPercentMonth, daysOverdue, installmentAmount);

            return interestValue;
        }

        public static decimal CalculatePenaltyPercent(decimal originalValue, decimal penaltyPercent)
        {
            return (originalValue * (penaltyPercent / 100));
        }

        private static decimal CalculateInterestPercentMonth(decimal interestPercent, int daysOverdue, decimal installmentAmount)
        {
            DateTime dateTimeNow = DateTime.Now;
            int monthDays = DateTime.DaysInMonth(dateTimeNow.Year, dateTimeNow.Month);

            return ((interestPercent / 100) / monthDays) * daysOverdue * installmentAmount;
        }
    }
}
