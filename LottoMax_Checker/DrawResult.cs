using System;
using System.Collections.Generic;
namespace Lotto_Checker
{
    public class DrawResult
    {
        private int _bonusNumber;

        public TicketFormat Format { get; }
        public ICollection<int> Numbers { get; }
        public int BonusNumber { 
            get 
            {
                if (!this.Format.HasBonusNumber)
                {
                    throw new InvalidOperationException("The TicketFormat for this DrawResult does not specify a Bonus Number.");
                }

                return _bonusNumber;
            }
        }

        public DrawResult(TicketFormat ticketFormat, ICollection<int> numbers)
        {
            this.Format = ticketFormat;

			if (numbers.Count != this.Format.NumberOfNumbers)
			{
				throw new ArgumentException("Ticket has the wrong number of numbers for the given format.\nTicket has " + numbers.Count + " while the format specifies " + this.Format.NumberOfNumbers);
			}

            foreach (var number in numbers)
            {
                if (number > this.Format.MaxNumber || number < this.Format.MinNumber)
                {
					throw new ArgumentException("One of the numbers in the result is out of range.");
                }
            }

            this.Numbers = numbers;
        }

        public DrawResult(TicketFormat ticketFormat, ICollection<int> numbers, int bonusNumber) : this(ticketFormat, numbers)
        {
            if (!ticketFormat.HasBonusNumber)
            {
                throw new ArgumentException("A bonus number was provided when the TicketFormat does not allow it.");
            }

			if (bonusNumber > this.Format.MaxNumber || bonusNumber < this.Format.MinNumber)
			{
				throw new ArgumentException("One of the numbers in the result is out of range.");
			}

            _bonusNumber = bonusNumber;
        }

        public override string ToString()
        {
            string result = "";

            foreach (var number in this.Numbers)
            {
                result += number;
                result += " ";
            }

            if (this.Format.HasBonusNumber)
            {
                result += "Bonus: ";
                result += this.BonusNumber;
            }

            result.TrimEnd();
            return result;
        }
    }
}
