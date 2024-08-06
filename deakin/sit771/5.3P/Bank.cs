
namespace _5_3P
{
    public class Bank
    {
        private List<Account> _accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public Account GetAccount(string name)
        {
            Account target = null;
            _accounts.ForEach(r =>
            {
                if (name.Equals(r.Name))
                {
                    target = r;
                }
            });

            return target;
        }

        public void ExecuteTransaction(WithdrawTransaction transaction)
        {
            transaction.Execute();
        }

        public void ExecuteTransaction(DepositTransaction transaction)
        {
            transaction.Execute();
        }

        public void ExecuteTransaction(TransferTransaction transaction)
        {
            transaction.Execute();
        }
    }
}