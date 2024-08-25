
namespace _7_1P
{
    public class Bank
    {
        private List<Account> _accounts = new List<Account>();

        private List<Transaction> _transactions= new List<Transaction>();


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

        public void ExecuteTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);

            transaction.Execute();
        }

        public void PrintTransactionHistory(){
            foreach (Transaction t in _transactions)
            {
                t.Print();
            }
        }

    }
}