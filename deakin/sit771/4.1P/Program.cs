using System;
using System.Text.RegularExpressions;
using SplashKitSDK;

namespace _4_1P
{
    enum MenuOption
    {
        Withdraw,
        Deposit,
        Transfer,
        Print,
        Quit
    }

    public class Program
    {
        public static void Main()
        {
            Account chrisAccount = new Account("Chris", 20000000);
            Account jakeAccount = new Account("Jake", 20000000);
            do
            {
                MenuOption option = ReadUserOption();
                switch (option)
                {
                    case MenuOption.Withdraw:
                        Console.WriteLine("withdraw {0}", DoWithdraw(chrisAccount) ? "success" : "fail");
                        break;
                    case MenuOption.Deposit:
                        Console.WriteLine("deposit {0}", DoDeposit(chrisAccount) ? "success" : "fail");
                        break;
                    case MenuOption.Transfer:
                        Console.WriteLine("Transfer from {0} to {1}, result {2}", jakeAccount.Name, chrisAccount.Name, DoTransfer(jakeAccount, chrisAccount) ? "success" : "fail");
                        break;
                    case MenuOption.Print:
                        DoPrint(chrisAccount);
                        break;
                    case MenuOption.Quit:
                    default:
                        return;
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
                    "|3 Transfer                |\r\n" +
                    "|4 Print                   |\r\n" +
                    "|5 Quit                    |\r\n" +
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
                );
                string optionStr = Console.ReadLine();
                if (!String.IsNullOrEmpty(optionStr) && Regex.IsMatch(optionStr, "^\\d{1}$"))
                {
                    int val = Convert.ToInt32(optionStr);
                    if (val >= 0 && val <= 5)
                    {
                        userOption = val;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("option should be a digital number which greater than 0 and less than 6");
                    }
                }
                else
                {
                    Console.WriteLine("invaild input");
                }

            } while (true);

            return (MenuOption)userOption - 1;
        }

        public static bool DoTransfer(Account fromAccount, Account toAccount)
        {
            decimal transferMoney;
            do
            {
                try
                {
                    Console.WriteLine("How much would you want to transfer?");
                    transferMoney = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("invalid input, please input again");
                }
            } while (true);

            try
            {
                TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, transferMoney);
                transfer.Execute();
                transfer.Print();

            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public static bool DoDeposit(Account account)
        {
            decimal depositMoney;
            do
            {
                try
                {
                    Console.WriteLine("How much would you want to deposit?");
                    depositMoney = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("invalid input, please input again");
                }
            } while (true);

            try
            {
                DepositTransaction deposit = new DepositTransaction(account, depositMoney);
                deposit.Execute();
                deposit.Print();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public static bool DoWithdraw(Account account)
        {
            decimal withdrawMoney;
            do
            {
                try
                {
                    Console.WriteLine("How much would you want to withdraw?");
                    withdrawMoney = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("invalid input, please input again");
                }
            } while (true);

            try
            {

                WithdrawTransaction withdraw = new WithdrawTransaction(account, withdrawMoney);
                withdraw.Execute();
                withdraw.Print();
            }
            catch (System.Exception)
            {

                Console.WriteLine($"Withdraw money fail, try again");
                return false;
            }

            return true;
        }
        public static void DoPrint(Account account)
        {
            account.Print();
        }

    }
}