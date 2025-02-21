namespace FinanzberaterHenno.Contracts
{
    public class Transaction
    {
        public DateOnly Date { get; }

        public double Amount { get; }

        public Recipient Recipient { get; }

        public TransactionType Type { get; set; }

        public string Purpose { get; }

        public bool Monthly { get; }

        public PaymentType PaymentType { get; }

        public Transaction(DateOnly date, double amount, string debitor, string purpose, PaymentType paymentType)
        {
            this.Date = date;
            this.Amount = amount;
            this.PaymentType = debitor.StartsWith("PayPal") ? PaymentType.PayPal : paymentType;
            this.Recipient = new Recipient(this.PaymentType != PaymentType.PayPal ? debitor : purpose);
            this.Type = this.Recipient.DefaultTransactionType;
            this.Purpose = purpose;
            

        }
    }
}
