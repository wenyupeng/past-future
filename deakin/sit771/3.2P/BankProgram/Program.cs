using System;
using System.Text.RegularExpressions;
using SplashKitSDK;
/**
* author: YUPENG WEN
* date: 20240717
*
*/
namespace BankProgram
{
    enum MenuOption
    {
        Withdraw,
        Deposit,
        Print,
        Quit
    }

    public class Program
    {
        public static void Main()
        {
            Account account = null;
            MenuOption option = ReadUserOption();
            switch (option)
            {
                case MenuOption.Withdraw:
                    DoWithdraw(account);
                    break;
                case MenuOption.Deposit:
                    DoDeposit(account);
                    break;
                case MenuOption.Print:
                    DoPrint(account);
                    break;
                case MenuOption.Quit:
                default:
                    break;
            }
        }

        private static MenuOption ReadUserOption()
        {
            int userOption = -1;
            do
            {

                Console.WriteLine(
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                    "|Please enter your option: |" +
                    "|1 Withdraw                |" +
                    "|2 Deposit                 |" +
                    "|3 Print                   |" +
                    "|4 Quit                    |" +
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
                );
                string optionStr = Console.ReadLine();
                if (!String.IsNullOrEmpty(optionStr) && Regex.IsMatch(optionStr, "^\\d{1}$"))
                {
                    int val = Convert.ToInt32(optionStr);
                    if (val >= 0 && val <= 3)
                    {
                        userOption = val;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("option should be a digital number which greater than 0 and less than 5");
                    }
                }
                else
                {
                    Console.WriteLine("invaild input");
                }

            } while (true);

            return (MenuOption)userOption - 1;
        }

        public static bool DoDeposit(Account account)
        {
            return true;
        }

        public static Account DoWithdraw(Account account)
        {
            return account;

        }
        public static void DoPrint(Account account)
        {
            account.Print();
        }

    }
}
