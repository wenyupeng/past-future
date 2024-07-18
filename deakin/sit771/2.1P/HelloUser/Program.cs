using System;
using System.Text.RegularExpressions;
using SplashKitSDK;

namespace HelloUser
{
    public class Program
    {
        public static void Main()
        {
            string name, inputText;
            int heightInCM;
            double weightInKG, heightInMeters, bmi;

            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            // Console.WriteLine("Hello "+name);
            Console.WriteLine($"Hello {name}");

            do
            {
                Console.Write("Please enter your height in centimeters: ");
                inputText = Console.ReadLine();
            } while (!Regex.IsMatch(inputText, "^[0-9]+$"));
            heightInCM = System.Convert.ToInt32(inputText);

            heightInMeters = heightInCM / 100.00;
            Console.WriteLine($"your height is {heightInMeters}");

            do
            {
                Console.Write("Please enter your weight in kilogram: ");
                inputText = Console.ReadLine();
            } while (!Regex.IsMatch(inputText, "^[0-9]+(.[0-9]{2})?$"));
            weightInKG = System.Convert.ToDouble(inputText);

            bmi = weightInKG / (heightInCM * heightInMeters)*100;
            Console.Write("your bmi is: " + bmi);
        }
    }
}
