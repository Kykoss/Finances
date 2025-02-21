using Finanzknabe.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanzberaterHenno.Contracts
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public double Amount { get; set; }

        public Recipient Recipient { get; set; }

        public TransactionType TransactionType { get; set; }

        public string Purpose { get; set; }

        public bool Monthly { get; set; }

        public PaymentType PaymentType { get; set; }

        public BankAccount Account { get; set; }

        public Transaction()
        {
        }

        public Transaction(BankAccount originAccount, DateOnly date, Recipient recipient, double amount, string debitor, string purpose, PaymentType paymentType)
        {
            this.Account = originAccount;
            this.Date = date;
            this.Amount = amount;
            this.PaymentType = debitor.StartsWith("PayPal") ? PaymentType.PayPal : paymentType;
            this.Recipient = recipient;
            this.TransactionType = this.Recipient.DefaultTransactionType;
            this.Purpose = purpose;
            
        }
    }
}
