using System;
using System.Text.RegularExpressions;
using SplashKitSDK;

namespace _5_3P
{

    enum MenuOption
    {
        Withdraw,
        Deposit,
        Transfer,
        NewAccount,
        Print,
        Quit,
    }

    public class Program
    {
        public static void Main()
        {
            Account chrisAccount = new Account("Chris", 20000000);
            Account jakeAccount = new Account("Jake", 20000000);

            Bank bank = new Bank();
            bank.AddAccount(chrisAccount);
            bank.AddAccount(jakeAccount);

            do
            {
                MenuOption option = ReadUserOption();
                switch (option)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(bank);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(bank);
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(bank);
                        break;
                    case MenuOption.NewAccount:
                        AddAccount(bank);
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

        private static Account FindAccount(Bank fromBank)
        {
            Console.Write("Enter account name: ");
            String name = Console.ReadLine();
            Account result = fromBank.GetAccount(name);
            if (result == null)
            {
                Console.WriteLine($"No account found with name {name}");
            }
            return result;
        }


        private static void AddAccount(Bank bank)
        {
            Console.WriteLine("Please input account name");
            String name = Console.ReadLine();
            Console.WriteLine("Please input its starting balance");
            decimal balance = 0;

            while (balance == 0)
            {
                try
                {
                    balance = decimal.Parse(Console.ReadLine());
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Please input a valid double");
                }
            }

            bank.AddAccount(new Account(name, balance));
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
                    "|4 NewAccount              |\r\n" +
                    "|5 Print                   |\r\n" +
                    "|6 Quit                    |\r\n" +
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
                );
                string optionStr = Console.ReadLine();
                if (!String.IsNullOrEmpty(optionStr) && Regex.IsMatch(optionStr, "^\\d{1}$"))
                {
                    int val = Convert.ToInt32(optionStr);
                    if (val >= 0 && val <= 6)
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

        public static void DoTransfer(Bank bank)
        {
            Account fromAccount = FindAccount(bank);
            if (fromAccount == null)
            {
                return;
            }

            Account toAccount = FindAccount(bank);
            if (toAccount == null)
            {
                return;
            }

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
                bank.ExecuteTransaction(transfer);
                transfer.Print();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Money transfer failed, try again");
            }
        }

        public static void DoDeposit(Bank toBank)
        {
            Account account = FindAccount(toBank);
            if (account == null)
            {
                return;
            }

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
                toBank.ExecuteTransaction(deposit);
                deposit.Print();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Money deposit failed");
            }
        }

        public static void DoWithdraw(Bank fromBank)
        {
            Account account = FindAccount(fromBank);
            if (account == null)
            {
                return;
            }

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
                fromBank.ExecuteTransaction(withdraw);
                withdraw.Print();
            }
            catch (System.Exception)
            {

                Console.WriteLine($"Withdraw money fail, try again");
            }

        }
        public static void DoPrint(Account account)
        {
            account.Print();
        }

    }
}
