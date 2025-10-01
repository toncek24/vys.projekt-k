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
                Console.Write($"Hráč {currents}, vyber pozici (1-9: ");
                string input Console.ReadLine();   

                if (!int.TryParse(input, out int pos)) || pos < 1 || pos > 9 || Board[pos - 1] == 'X' || Board[pos - 1] == 'O')
                        continue;
                Board[pos - 1] = currents;
                move++;

                if (Win())
                {
                    Console.Clear();
                    Draw();
                    Console.WriteLine($"Hráč {currents} vyhrál");
                    break;
                }

                if (move == 9)
                {
                    Console.Clear();
                    Draw();
                    Console.WriteLine("remíza");
                    break;
                }

                currents = currents == 'X' ? 'O' : 'X';
            }
        }
        static void Draw()
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        }

        static bool Win()
        {
            int[,] 
        }

    }
}
