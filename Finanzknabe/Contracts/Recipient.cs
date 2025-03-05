using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzknabe.Contracts
{
    public class Recipient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public TransactionType DefaultTransactionType { get; set; } = TransactionType.Uncategorized;

        public Recipient()
        {
        }

        public Recipient(string name)
        {
            this.Name = name;
        }
    }
}
