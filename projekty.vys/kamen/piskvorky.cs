using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kamen
{
    internal class piskvorky
    {
        static char[] board = { '1', '2', '3', "4", "5", "6", "7", "8", "9" };
        static char currentplayer = "X";
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine($"Hráč {currentplayer}, zadej číslopole: ");

                string input = Console.ReadLine();
            }
        }
    }
}
