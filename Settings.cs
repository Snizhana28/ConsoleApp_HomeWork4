using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_HomeWork4
{
    public class Settings
    {
        public List<Player> Players = new List<Player>();
        private static int FirstPlayer;
        public Settings()
        {
            StarSetting();
            FirstTurn();
            SetSymbolPlayer();
        }

        private void SetSymbolPlayer()
        {
            Players[0].symbol = 'O';
            Players[1].symbol = 'X';
        }

        private void StarSetting()
        {
            bool ErrorCheck = true;
            while (ErrorCheck)
            {
                ErrorCheck = WriteName("Enter name Player 1 ");
            }
            bool CheckSymbol = true;
            while (CheckSymbol)
            {
                Console.WriteLine();
                Console.WriteLine("Who to play ?\n1. Bot\n2. Friend");
                int player = int.TryParse(Console.ReadLine(), out player) ? player : 0;
                switch (player)
                {
                    case 1:
                        Players.Add(new Player("Computer"));
                        CheckSymbol = false;
                        break;
                    case 2:
                        while (WriteName("Enter name Player 2 "))
                        {

                        }
                        CheckSymbol = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid value");
                        CheckSymbol = true;
                        break;
                }
            }
            bool WriteName(string text)
            {
                Console.WriteLine(text);
                string Name = Console.ReadLine();
                if (Name != null & Name != "")
                {
                    Players.Add(new Player(Name));
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error in the name");
                    return true;
                }
            }
        }

        public Player FirstTurn()
        {
            Random rnd = new Random();
            FirstPlayer = rnd.Next(0, 2);
            return Players[FirstPlayer];
        }
        public Player swithTurn()
        {
            if (FirstPlayer == 1)
            {
                FirstPlayer--;
                return Players[0];
            }
            else
            {
                FirstPlayer++;
                return Players[1];
            }

        }
    }
}
