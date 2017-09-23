using System;
using System.Collections.Generic;
namespace Lotto_Checker
{
    public class Ticket
    {
        public TicketFormat Format { get; }
        public ICollection<ICollection<int>> Numbers { get; }

        public Ticket(TicketFormat ticketFormat, ICollection<ICollection<int>> numbers)
        {
            this.Format = ticketFormat;

            foreach (var numberRow in numbers)
            {
                if (numberRow.Count != this.Format.NumberOfNumbers)
                {
                    throw new ArgumentException("Ticket has the wrong number of numbers for the given format.\nTicket has " + numberRow.Count + " while the format specifies " + this.Format.NumberOfNumbers);
                }
            }

            foreach (var numberRow in numbers)
            {
                foreach (var number in numberRow)
                if (number > this.Format.MaxNumber || number < this.Format.MinNumber)
                {
                    throw new ArgumentException("One of the numbers on the ticket is out of range.");
                }
            }

            this.Numbers = numbers;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var numberRow in this.Numbers)
            {
                foreach (var number in numberRow)
                {
                    result += number;
                    result += " ";
                }
                result.TrimEnd();
                result += "\n";
            }

            return result;
        }

        public ICollection<string> GetTicketRows()
        {
            ICollection<string> result = new List<string>();

            foreach (var numberRow in this.Numbers)
            {
                string row = "";
                foreach (var number in numberRow)
                {
                    row += number;
                    row += " ";
                }
                row.TrimEnd();
                result.Add(row);
            }

            return result;
        }
    }
}