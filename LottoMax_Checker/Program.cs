using System;
using System.Collections.Generic;
namespace Lotto_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticketFormatMain = new TicketFormat(7, 49, 1, true);    // Format for LottoMax Main Draw

            var rows = new List<ICollection<int>>() 
            {
                new List<int>() {11, 15, 20, 21, 22, 31, 45},
                new List<int>() {17, 21, 26, 28, 32, 37, 47},
                new List<int>() {1, 4, 11, 13, 18, 21, 40}
            };

            var ticketMain = new Ticket(ticketFormatMain, rows as ICollection<ICollection<int>>);

            var mainDrawResult = new List<DrawResult>() 
            {
                new DrawResult(ticketFormatMain, new List<int>() {2, 10, 37, 38, 39, 43, 47} as ICollection<int>, 28)
            };

            var mainDraw = new Draw(mainDrawResult as ICollection<DrawResult>, ticketFormatMain);

            Console.WriteLine("Main Draw");
            Console.Write(mainDraw.CheckResults(ticketMain));

            Console.WriteLine("MaxMillions");

            var ticketFormatMaxMillions = new TicketFormat(7, 49, 1, false);    // Format for MaxMillions

            var ticketMaxMillion = new Ticket(ticketFormatMaxMillions, rows as ICollection<ICollection<int>>);

            var maxDrawResult = new List<DrawResult>()
            {
                new DrawResult(ticketFormatMaxMillions, new List<int>() {1, 2, 8, 10, 15, 23, 49} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {1, 5, 7, 9, 10, 17, 26} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {1, 10, 17, 23, 28, 33, 43} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {3, 4, 22, 29, 31, 41, 42} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {4, 5, 8, 28, 35, 47, 49} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {5, 14, 31, 35, 44, 48, 49} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {6, 17, 20, 21, 34, 38, 47} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {11, 16, 18, 19, 28, 33, 35} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {1, 4, 13, 38, 43, 46, 48} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {1, 5, 11, 15, 30, 44, 49} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {2, 10, 12, 13, 19, 31, 47} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {3, 11, 19, 26, 28, 31, 42} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {4, 6, 16, 19, 24, 30, 42} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {6, 8, 15, 21, 44, 45, 49} as ICollection<int>),
                new DrawResult(ticketFormatMaxMillions, new List<int>() {7, 12, 14, 16, 24, 38, 47} as ICollection<int>)

            };

            var maxDraw = new Draw(maxDrawResult as ICollection<DrawResult>, ticketFormatMaxMillions);

            Console.Write(maxDraw.CheckResults(ticketMaxMillion));
        }
    }
}
