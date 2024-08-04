using System;

namespace _5_1P
{
    public class Program
    {
        public static void Main()
        {
            int numberOfValues = ReadInteger("Please enter a integer number of the store array");
            double[] values = new double[numberOfValues];
            for (int i = 0; i < numberOfValues; i++)
            {
                values[i] = ReadDouble($"Enter the {i + 1} st value");
            }

            double sum = 0;
            foreach (var item in values)
            {
                Console.WriteLine($"output value: {item}");
                sum += item;
            }

            Console.WriteLine($"the sum is {sum}");
        }

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

                    Console.WriteLine("Please enter a valid integer");
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

                    Console.WriteLine("Please enter a valid double");
                }
            }
        }
    }
}
