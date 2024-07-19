using System;
using SplashKitSDK;
/**
* author: YUPENG WEN
* date: 20240717
*
*/
namespace BankProgram
{
    public class Program
    {
        public static void Main()
        {
            Account chrisAccount =new Account("Chris",200000);
            chrisAccount.Print();
            chrisAccount.Deposit(100);
            chrisAccount.Print();

            chrisAccount.Withdraw(20000);
            chrisAccount.Print();

            Account tomAccount =new Account("Tom",10000);
            tomAccount.Print();
            tomAccount.Deposit(180);
            tomAccount.Print();

            tomAccount.Withdraw(1000);
            tomAccount.Print();

        }
    }
}
