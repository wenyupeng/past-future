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
            Account account =new Account("Chris",200000);
            account.Print();
            account.Deposit(100);
            account.Print();

            account.Withdraw(20000);
            account.Print();
        }
    }
}
