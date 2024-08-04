using System;
using SplashKitSDK;

namespace _5_2P
{
    public enum UserOption
    {
        NewValue,
        Sum,
        Print,
        Quit
    }

    public class Program
    {
        private static List<double> _values = new List<double>();

        public static int ReadInteger(string prompt)
        {
            Console.WriteLine(prompt);
            while (true)
            {
                try
                {
                    return Int32.Parse(Console.ReadLine());
                }
                catch (System.Exception)
                {

                    Console.WriteLine("Please input a valid integer");
                }


            }
        }

        public static double ReadDouble(string prompt)
        {
            Console.WriteLine(prompt);
            while (true)
            {
                try
                {
                    return Double.Parse(Console.ReadLine());
                }
                catch (System.Exception)
                {

                    Console.WriteLine("Please input a valid double");
                }


            }
        }

        public static void AddValueToList()
        {
            _values.Add(ReadDouble("Please input the double number that you want to store"));
        }

        public static void Print()
        {
            Console.Write("[");
            foreach (var item in _values)
            {
                Console.Write(item + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        public static void Sum()
        {
            double sum = 0;
            foreach (var item in _values)
            {
                sum += item;
            }
            Console.WriteLine($"the sum is {sum}");
        }

        public static UserOption ReadUserOption()
        {
            Console.WriteLine("Enter 0 to add a value");
            Console.WriteLine("Enter 1 to add a sum all values");
            Console.WriteLine("Enter 2 to print a sum all values");
            Console.WriteLine("Enter 3 to quit");

            int option = 3;
            Int32.TryParse(Console.ReadLine(), out option);

            return (UserOption)option;
        }

        public static void Main()
        {
            UserOption option = UserOption.Quit;
            do
            {
                option = ReadUserOption();
                switch (option)
                {
                    case UserOption.NewValue:
                        AddValueToList();
                        break;
                    case UserOption.Sum:
                        Sum();
                        break;
                    case UserOption.Print:
                        Print();
                        break;
                    case UserOption.Quit:
                    default:
                        break;
                }

            } while (option != UserOption.Quit);
        }
    }
}
