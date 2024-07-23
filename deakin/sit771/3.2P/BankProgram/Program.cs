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
            Account account = new Account("Chris", 20000000);
            do
            {
                MenuOption option = ReadUserOption();
                switch (option)
                {
                    case MenuOption.Withdraw:
                        Console.WriteLine("withdraw {0}",DoWithdraw(account)?"success":"fail");
                        break;
                    case MenuOption.Deposit:
                        Console.WriteLine("withdraw {0}",DoDeposit(account)?"success":"fail");
                        break;
                    case MenuOption.Print:
                        DoPrint(account);
                        break;
                    case MenuOption.Quit:
                    default:
                        break;
                }
            } while (true);
        }

        private static MenuOption ReadUserOption()
        {
            int userOption = -1;
            do
            {

                Console.WriteLine(
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~\r\n" +
                    "|Please enter your option: |\r\n" +
                    "|1 Withdraw                |\r\n" +
                    "|2 Deposit                 |\r\n" +
                    "|3 Print                   |\r\n" +
                    "|4 Quit                    |\r\n" +
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
            int depositMoney;
            do
            {
                try
                {
                    Console.WriteLine("How much would you want to deposit?");
                    depositMoney = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("invalid input, please input again");
                }
            } while (true);
            return account.Deposit(depositMoney);
        }

        public static bool DoWithdraw(Account account)
        {
            int withdrawMoney;
            do
            {
                try
                {
                    Console.WriteLine("How much would you want to withdraw?");
                    withdrawMoney = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("invalid input, please input again");
                }
            } while (true);
            return account.Withdraw(withdrawMoney);

        }
        public static void DoPrint(Account account)
        {
            account.Print();
        }

    }
}
