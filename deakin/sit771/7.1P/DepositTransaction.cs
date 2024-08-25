namespace _7_1P
{
    public class DepositTransaction:Transaction
    {
        private Account _account;
        private bool _success;

        public DepositTransaction(Account account, decimal amount):base(amount)
        {
            _account = account;
        }

        public override bool Success
        {
            get{return _success;}
        }


        public override void Print()
        {
            Console.WriteLine($"deposit amount {_amount} {(_success ? "success" : "fail")}");
            _account.Print();
        }

        public override void Execute()
        {
            base.Execute();
            _success = _account.Deposit(_amount);

        }

        public override void Rollback()
        {
            base.Rollback();

            _success = _account.Deposit(-_amount);
        }

    }
}