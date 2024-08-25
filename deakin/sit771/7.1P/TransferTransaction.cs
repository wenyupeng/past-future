namespace _7_1P
{
    public class TransferTransaction : Transaction
    {
        private Account _toAccount;
        private Account _fromAccount;
        private DepositTransaction _theDeposit;
        private WithdrawTransaction _theWithdraw;
        private bool _success;
        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;

            _theDeposit = new DepositTransaction(toAccount, amount);
            _theWithdraw = new WithdrawTransaction(fromAccount, amount);
        }

        public override bool Success
        {
            get { return _theDeposit.Success && _theWithdraw.Success; }
        }

        public override void Print()
        {
            Console.WriteLine($"Transferred  amount {_amount} from {_fromAccount.Name} to {_toAccount.Name}");
            _theDeposit.Print();
            _theWithdraw.Print();
        }

        public override void Execute()
        {
            base.Execute();

            try
            {
                _theWithdraw.Execute();
            }
            catch (System.Exception)
            {
                _success = false;
                throw new Exception("transfer failed, try again later");
            }

            if (_theWithdraw.Success)
            {
                try
                {
                    _theDeposit.Execute();
                }
                catch (System.Exception)
                {
                    _success = false;
                    _theWithdraw.Rollback();
                    throw new Exception("transfer failed, withdraw success first and deposit fail, it has been rollback, try again later");
                }
            }

            _success = true;
        }

        public override void Rollback()
        {
            base.Rollback();

            if (_theDeposit.Success)
            {
                _theDeposit.Rollback();
            }

            if (_theWithdraw.Success)
            {
                _theWithdraw.Rollback();
            }
        }
    }

}