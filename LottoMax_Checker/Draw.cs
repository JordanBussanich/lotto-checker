using System;
using System.Collections.Generic;
namespace Lotto_Checker
{
    public class Draw
    {
        public ICollection<DrawResult> Results { get; }
        public TicketFormat Format { get; }

        public Draw(ICollection<DrawResult> results, TicketFormat ticketFormat)
        {
            if (results.Count < 1)
            {
                throw new ArgumentException("Draw must have at least one DrawResult");
            }

            foreach (var result in results)
            {
                if (!result.Format.Equals(ticketFormat))
                {
                    throw new ArgumentException("One of the given DrawResults does not have the same format as the specified Draw");
                }
            }

            this.Results = results;
            this.Format = ticketFormat;
        }

        public string CheckResults(Ticket ticket)
        {
            if (!CheckTicketFormat(ticket))
            {
                throw new ArgumentException("The provided Ticket does not have the same TicketFormat as this Draw");
            }

            string result = "";
            var rowStrings = ticket.GetTicketRows();

            foreach (var drawResult in this.Results)
            {
                var en = rowStrings.GetEnumerator();
                en.Reset();
                en.MoveNext();

                foreach (var numberRow in ticket.Numbers)
                {
                    int matches = 0;
                    bool gotBonus = false;
                    foreach (var ticketNumber in numberRow)
                    {
                        foreach (var resultNumber in drawResult.Numbers)
                        {
                            if (resultNumber == ticketNumber)
                            {
                                matches++;
                            }
                        }

                        if (this.Format.HasBonusNumber)
                        {
                            if (ticketNumber == drawResult.BonusNumber)
                            {
                                gotBonus = true;
                            }
                        }
                    }

                    result += en.Current;
                    result += "\t - ";
                    result += matches;
                    result += " matches";

                    if (this.Format.HasBonusNumber)
                    {
                        if (gotBonus)
                        {
                            result += " plus the bonus number";
                        }
                    }

                    result += "\n";
                    en.MoveNext();
                }
                result += "-------------------\n\n";
            }

            return result;
        }

        public bool CheckTicketFormat(Ticket ticket)
        {
            return ticket.Format.Equals(this.Format);
        }
    }
}
