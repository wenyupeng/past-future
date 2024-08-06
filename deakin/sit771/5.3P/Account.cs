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

    public bool Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("cannot withdraw a negative amount");
            return false;
        }
        else if (_balance < amount)
        {
            return false;
        }
        else
        {
            _balance -= amount;
            return true;
        }
    }

    public bool Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            return true;
        }
        return false;
    }

}