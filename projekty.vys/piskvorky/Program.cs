using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kamen
{
    internal class piskvorky
    {
        static char[] Board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char currents = 'X';
        static void Main()
        {
            int move = 0;
            while (true)
            {
                Console.Clear();
                Draw();
                Console.Write($"Hráč {currents}, vyber pozici (1-9): ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int pos) || pos < 1 || pos > 9 || Board[pos - 1] == 'X' || Board[pos - 1] == 'O')
                    continue;

                Board[pos - 1] = currents;
                move++;

                if (Win())
                {
                    Console.Clear();
                    Draw();
                    Console.WriteLine($"Hráč {currents} vyhrál!");
                    break;
                }

                if (move == 9)
                {
                    Console.Clear();
                    Draw();
                    Console.WriteLine("Remíza!");
                    break;
                }

                currents = currents == 'X' ? 'O' : 'X';
            }
        }

        static void Draw()
        {
            Console.WriteLine($"{Board[0]} | {Board[1]} | {Board[2]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{Board[3]} | {Board[4]} | {Board[5]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{Board[6]} | {Board[7]} | {Board[8]}");
        }

        static bool Win()
        {
            int[,] Wins = {
                {0,1,2},{3,4,5},{6,7,8},
                {0,3,6},{1,4,7},{2,5,8},
                {0,4,8},{2,4,6}
            };

            for (int i = 0; i < Wins.GetLength(0); i++)
            {
                if (Board[Wins[i, 0]] == currents &&
                    Board[Wins[i, 1]] == currents &&
                    Board[Wins[i, 2]] == currents)
                    return true;
            }
            return false;
        }
    }
}
