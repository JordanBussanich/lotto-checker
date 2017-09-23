using System;
namespace Lotto_Checker
{
    public class TicketFormat
    {
        public int NumberOfNumbers { get; }
        public int MaxNumber { get; }
        public int MinNumber { get; }
        public bool HasBonusNumber { get; }

        public TicketFormat(int numberOfNumbers, int maxNumber, int minNumber, bool hasBonusNumber)
        {
            if (numberOfNumbers < 1)
            {
                throw new ArgumentException("Ticket must have at least one number on it.");
            }

            if (maxNumber < minNumber)
            {
                throw new ArgumentException("MaxNumber must be greater than MinNumber.");
            }

            this.NumberOfNumbers = numberOfNumbers;
            this.MaxNumber = maxNumber;
            this.MinNumber = minNumber;
            this.HasBonusNumber = hasBonusNumber;
        }
    }
}
