using System;
using System.Numerics;
using System.Text.RegularExpressions;
using SplashKitSDK;

namespace NameTester
{
    public enum MenuOption
    {
        TestName,
        GuessThatNumber,
        Quit
    }

    public class Program
    {
        public static void Main()
        {
            MenuOption userSelection;

            do
            {

                userSelection = ReadUserOption();
                Console.WriteLine(userSelection);
                switch (userSelection)
                {
                    case MenuOption.TestName:
                        TestName();
                        break;
                    case MenuOption.GuessThatNumber:
                        RunGuessThatNumber();
                        break;
                    case MenuOption.Quit:
                    default:
                        break;
                }
            } while (userSelection != MenuOption.Quit);
        }
        private static int ReadGuess(int min, int max)
        {
            Console.WriteLine("Enter your guess between {0} and {1}", min, max);
            string guessValStr = "";
            int guessVal = -1;
            do
            {
                guessValStr = Console.ReadLine();
                if (!String.IsNullOrEmpty(guessValStr) && Regex.IsMatch(guessValStr, "^\\d+$"))
                {
                    guessVal = Convert.ToInt32(guessValStr);
                    if (guessVal > min && guessVal < max)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("you guessed wrong");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);
            return guessVal;
        }
        private static void RunGuessThatNumber()
        {
            int lowestVal = 1, highestVal = 100, guessVal = -1;
            int targetVal = new Random().Next(100) + 1;

            while (true)
            {
                Console.WriteLine("Guess a number between 1 and 100");
                guessVal = ReadGuess(lowestVal, highestVal);

                if (guessVal < targetVal)
                {
                    Console.WriteLine("guessed value is smaller than target value");
                    lowestVal = guessVal;
                }
                else if (guessVal > targetVal)
                {
                    Console.WriteLine("guessed value is bigger than target value");
                    highestVal = guessVal;
                }
                else
                {
                    Console.WriteLine("you guessed right, target value is {0}", targetVal);
                    break;
                }

            }
        }

        private static void TestName()
        {
            Console.WriteLine("Please input your name");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello {0}", userName);

            if (userName.ToLower() == "chris")
            {
                Console.WriteLine("Welcome my creator");
            }
            else if (userName.ToLower() == "tina")
            {
                Console.WriteLine("Welcome Chris's friend {0}", userName);
            }
            else
            {
                Console.WriteLine("Welcome user {0}", userName);
            }
        }
        private static MenuOption ReadUserOption()
        {
            Console.WriteLine(
                "---------------------------------\r\n" +
                "| 1 will run Test Name          |\r\n" +
                "| 2 will play Guess That Number |\r\n" +
                "| 3 will Quit                   |\r\n" +
                "---------------------------------\r\n"
            );

            int option = -1;
            string optionStr = "";

            try
            {

                do
                {
                    Console.WriteLine("Choose an option[1-3]:");
                    optionStr = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(optionStr) && Regex.IsMatch(optionStr, "^\\d{1}$"))
                    {
                        option = System.Convert.ToInt32(optionStr);
                        if (option >= 1 && option <= 3)
                        {
                            break;
                        }
                    }
                    Console.WriteLine("invalid input, please reinput");
                } while (true);
            }
            catch
            {
                option = -1;
            }

            return (MenuOption)(option - 1);
        }
    }
}
