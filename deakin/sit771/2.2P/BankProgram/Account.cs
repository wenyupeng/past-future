using System;
public class Account
{
    private decimal _balance;
    private string _name;

    public Account(string _name, decimal _balance)
    {
        this._name = _name;
        this._balance = _balance;
    }

    public string Name
    {
        get { return _name; }
    }

    public void Print()
    {
        Console.WriteLine($"Hi {_name}, your balance is {_balance}");
    }

    public void Withdraw(decimal amount)
    {
        if (_balance < amount)
        {
            Console.WriteLine($"sorry {_name}, you do not have enough money to withdraw");
        }
        else
        {
            _balance -= amount;
            Console.WriteLine($"you have successfull withdraw {amount}");
        }
    }

    public void Deposit(decimal amount)
    {

        _balance += amount;
        Console.WriteLine($"sucessful add {amount}");
    }

}