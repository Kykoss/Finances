namespace FinanzberaterHenno.Contracts
{
    public class Recipient
    {
        public string Name { get; }

        public TransactionType DefaultTransactionType { get; } = TransactionType.Uncategorized;

        public Recipient(string name)
        {
            this.Name = name;
        }

    }
}
