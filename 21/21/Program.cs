using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21
{
    class Blackjack
    {
        static string[] playerCards = new string[9];
        static string goOrStop = "";
        static int score = 0, count = 1, dealerScore = 0;
        static Random cardRandomizer = new Random();

        static void Main(string[] args)
        {
            Console.Title = "Blackjack! is Begin";
            Start();
        }
        static void Start()
        {
            dealerScore = cardRandomizer.Next(15, 22);
            playerCards[0] = Deal();
            playerCards[1] = Deal();
            do
            {
                Console.WriteLine("Welcome to Blackjack! \nYour card " + playerCards[0] + " and " + playerCards[1] + ". \nYour score is " + score + ".\nDo you want to continue or not? \nif yes write go if no write stop");
                goOrStop = Console.ReadLine().ToLower();
            } while (!goOrStop.Equals("go") && !goOrStop.Equals("stop"));
            Game();
        }
        static void Game()
        {
            if (goOrStop.Equals("go"))
            {
                Go();
            } else if (goOrStop.Equals("stop"))
            {
                if (score > dealerScore && score <= 21)
                {
                    Console.WriteLine("\nCongrats! You won the game! The dealer score was " + dealerScore + ".\nWould you like to play again? y/n");
                    PlayAgain();
                } else if (score < dealerScore)
                {
                    Console.WriteLine("\nSorry, you lost! The dealer score was " + dealerScore + ".\nWould you like to play again? y/n");
                    PlayAgain();
                }
            }
            Console.ReadLine();
        }
        static string Deal()
        {
            string Card = "";
            int cards = cardRandomizer.Next(1, 9);
            switch (cards)
            {
                
                case 1:
                    Card = "Six"; score += 6;
                    break;
                case 2:
                    Card = "Seven"; score += 7;
                    break;
                case 3:
                    Card = "Eight"; score += 8;
                    break;
                case 4:
                    Card = "Nine"; score += 9;
                    break;
                case 5:
                    Card = "Ten"; score += 10;
                    break;
                case 6:
                    Card = "Jack"; score += 2;
                    break;
                case 7:
                    Card = "Queen"; score += 3;
                    break;
                case 8:
                    Card = "King"; score += 4;
                    break;
                case 9:
                    Card = "Ace"; score += 11;
                    break;                                                   
            }
            return Card;
        }
        static void Go()
        {
            count += 1;
            playerCards[count] = Deal();
            Console.WriteLine("\nYou were get " + playerCards[count] + ".\nYour new score is " + score + ".");
            if (score.Equals(21))
            {
                Console.WriteLine("\nYou got Blackjack! The dealer score was " + dealerScore + ".\nWould you like to play again?");
                PlayAgain();
            } else if (score > 21)
            {
                Console.WriteLine("\nYou busted, therefore you lost. Sorry. The dealer's score was " + dealerScore + ".\nWould you like to play again? y/n");
                PlayAgain();
            } else if (score < 21)
            {
                do
                {
                    Console.WriteLine("\nWould you like to go or stop?");
                    goOrStop = Console.ReadLine().ToLower();
                } while (!goOrStop.Equals("go") && !goOrStop.Equals("stop"));
                Game();
            }
        }
        static void PlayAgain()
        {
            string playAgain = "";
            do
            {
                playAgain = Console.ReadLine().ToLower();
            } while (!playAgain.Equals("y") && !playAgain.Equals("n"));
            if (playAgain.Equals("y"))
            {
                Console.WriteLine("\nPress enter to restart the game!");
                Console.ReadLine();
                Console.Clear();
                dealerScore = 0;
                count = 1;
                score = 0;
                Start();
            } else if (playAgain.Equals("n"))
            {
                Console.WriteLine("\nPress enter to close Blackjack.");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
