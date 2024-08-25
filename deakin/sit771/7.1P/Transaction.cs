namespace _7_1P
{
    public abstract class Transaction
    {
        protected decimal _amount;
        private bool _executed;
        private bool _reversed;
        private DateTime _dateStamp;

        public Transaction(decimal amount)
        {
            _amount = amount;
        }

        public bool Executed
        {
            get { return _executed; }
        }

        public abstract bool Success
        {
            get;
        }

        public bool Reversed
        {
            get { return _reversed; }
        }

        public DateTime DateStamp
        {
            get { return _dateStamp; }
        }

        public abstract void Print();

        public virtual void Execute()
        {
            if (_executed)
            {
                throw new Exception("Transaction have be executed");
            }

            _executed = true;

            _dateStamp = DateTime.Now;
        }

        public virtual void Rollback()
        {
            if (_reversed)
            {
                throw new Exception("Transaction have be reversed");
            }

            _reversed = true;
            
            _dateStamp = DateTime.Now;
        }

    }
}