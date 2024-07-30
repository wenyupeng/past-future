namespace _4_1P
{
    public class TransferTransaction
    {
        private Account _toAccount;
        private Account _fromAccount;
        private decimal _amount;

        private DepositTransaction _theDeposit;
        private WithdrawTransaction _theWithdraw;
        private bool _executed;
        private bool _success;
        private bool _reversed;
        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;

            _theDeposit = new DepositTransaction(toAccount, amount);
            _theWithdraw = new WithdrawTransaction(fromAccount, amount);
        }


        public bool Executed
        {
            get { return _executed; }
        }

        public bool Success
        {
            get { return _theDeposit.Success && _theWithdraw.Success; }
        }
        public bool Reversed
        {
            get { return _reversed; }
        }

        public void Print()
        {
            Console.WriteLine($"Transferred  amount {_amount} from {_fromAccount.Name} to {_toAccount.Name}");
            _theDeposit.Print();
            _theWithdraw.Print();
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new Exception("Cannot execute this transaction as it has already been executed");
            }

            try
            {
                _theWithdraw.Execute();
            }
            catch (System.Exception)
            {

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

                    _theWithdraw.Rollback();
                    throw new Exception("transfer failed, withdraw success first and deposit fail, it has been rollback, try again later");
                }
            }

            _executed = true;
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

            if(_theDeposit.Success){
                _theDeposit.Rollback();
            }

            if(_theWithdraw.Success){
                _theWithdraw.Rollback();
            }
        }
    }

}