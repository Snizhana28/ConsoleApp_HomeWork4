using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_HomeWork4
{
    public class NaughtsAndCrosses
    {
        private char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private Player gambler;
        private Settings settings = new Settings();

        public NaughtsAndCrosses()
        {
            gambler = settings.FirstTurn();
            PlayGame();
        }

        private void CheckTurn(int choice)
        {
            if (board[choice] != 'X' && board[choice] != 'O')
            {
                char currentPlayerSymbol = gambler.symbol;
                board[choice] = currentPlayerSymbol;
            }
            else
            {
                Console.WriteLine("Invalid move! Try again");
                Console.ReadLine();
            }
        }

        private void DrawMap()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int index = i * 3 + j;
                    Console.Write($" {board[index]} ");

                    if (j < 2)
                        Console.Write("|");
                }
                Console.WriteLine();

                if (i < 2)
                    Console.WriteLine("---|---|---");
            }
        }

        private bool CheckWin()
        {
            for (int i = 0; i < 8; i++)
            {
                string line = "";
                switch (i)
                {
                    case 0:
                        line = $"{board[0]}{board[1]}{board[2]}";
                        break;
                    case 1:
                        line = $"{board[3]}{board[4]}{board[5]}";
                        break;
                    case 2:
                        line = $"{board[6]}{board[7]}{board[8]}";
                        break;
                    case 3:
                        line = $"{board[0]}{board[3]}{board[6]}";
                        break;
                    case 4:
                        line = $"{board[1]}{board[4]}{board[7]}";
                        break;
                    case 5:
                        line = $"{board[2]}{board[5]}{board[8]}";
                        break;
                    case 6:
                        line = $"{board[0]}{board[4]}{board[8]}";
                        break;
                    case 7:
                        line = $"{board[2]}{board[4]}{board[6]}";
                        break;
                }
                if (line == "XXX" || line == "OOO")
                    return true;
            }
            return false;
        }

        private void PlayGame()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("A tic-tac-toe game\n");

                DrawMap();

                gambler = settings.swithTurn();

                Console.WriteLine($"\nPlayer's turn {gambler.Name} ({gambler.symbol})");
                int choice;
                if (gambler.Name == "Computer")
                {
                    Random random = new Random();
                    do
                    {
                        choice = random.Next(0, 9);
                    }
                    while (board[choice] == 'X' || board[choice] == 'O');
                }
                else
                {
                    choice = int.Parse(Console.ReadLine()) - 1;
                }
                CheckTurn(choice);
            }
            while (!CheckWin());

            Console.Clear();
            DrawMap();
            Console.WriteLine($"Player {gambler.Name} won!");
            Console.ReadLine();
        }
    }
}
