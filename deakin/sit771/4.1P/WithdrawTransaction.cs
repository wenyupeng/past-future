
namespace _4_1P
{
    public class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        public WithdrawTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Success
        {
            get { return _success; }
        }

        public bool Reversed
        {
            get { return _reversed; }
        }

        public void Print()
        {
            Console.WriteLine($"withdraw amount {_amount} {(_success?"success":"fail")}");
            _account.Print();
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new Exception("Cannot execute this transaction as it has already been executed");
            }

            _executed = true;

            _success = _account.Withdraw(_amount);

        }

        public void Rollback()
        {
            if (!_executed)
            {
                throw new Exception("Rollback of unexecuted transactions is not allowed");
            }

            if (_reversed)
            {
                throw new Exception("Repeated rollback is not allowed");
            }

            _reversed = _account.Withdraw(-_amount);
        }
    }
}